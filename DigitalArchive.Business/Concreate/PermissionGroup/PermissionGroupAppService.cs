using DigitalArchive.Business.Abstract;
using DigitalArchive.Business.ValidationRules.FluentValidation.PermissionGroup;
using DigitalArchive.Core.Aspects.AutoFac.Authorize;
using DigitalArchive.Core.Aspects.AutoFac.Validation;
using DigitalArchive.Core.Authorization;
using DigitalArchive.Core.DbModels;
using DigitalArchive.Core.Dto.Response;
using DigitalArchive.Core.Extensions.Linq;
using DigitalArchive.Core.Repositories;
using DigitalArchive.Entities.ViewModels.PermissionGroupVM;
using Microsoft.EntityFrameworkCore;

namespace DigitalArchive.Business.Concreate
{

    public class PermissionGroupAppService : BaseAppService, IPermissionGroupAppService
    {
        private readonly IRepository<PermissionGroup, int> _permissionGroupRepository;
        public PermissionGroupAppService(IRepository<PermissionGroup, int> permissionGroupRepository)
        {
            _permissionGroupRepository = permissionGroupRepository;
        }
        [AuthorizeAspect(new string[] { AllPermissions.PermissionGroup_List })]
        public async Task<PagedResult<GetAllPermissionGroupInfo>> GetAllPermissionGroupByPage(GetAllPermissionGroupInput input)
        {
            var query = _permissionGroupRepository.GetAll().Where(x=>!x.IsDeleted);

            query = query.WhereIf(!string.IsNullOrEmpty(input.SearchText), x => x.Name.Contains(input.SearchText));

            var totalPermissionGroupCount = await query.CountAsync();

            var permissionGroups = await query.PageBy(input.SkipCount, input.MaxResultCount).ToListAsync();

            var mappedPermissionGroups = Mapper.Map<List<GetAllPermissionGroupInfo>>(permissionGroups);

            return new PagedResult<GetAllPermissionGroupInfo>(totalPermissionGroupCount, mappedPermissionGroups);
        }

        public async Task<GetAllPermissionGroupInfo> GetPermissionGroupById(int permissionGroupId)
        {
            var permissionGroup = await _permissionGroupRepository.FirstOrDefaultAsync(x => x.Id == permissionGroupId && !x.IsDeleted);
            if (permissionGroup == null)
            {
                throw new Exception($"{permissionGroupId} nolu Id degeri bulunamadı");
            }
            var mappedCategory = Mapper.Map<GetAllPermissionGroupInfo>(permissionGroup);
            return mappedCategory;
        }

        public async Task<ListResult<GetAllPermissionGroupInfo>> GetPermissionGroupList()
        {
            var query = await _permissionGroupRepository.GetAll().Where(x => !x.IsDeleted).ToListAsync();

            var mappedPermissionGroup = Mapper.Map<List<GetAllPermissionGroupInfo>>(query);

            return new ListResult<GetAllPermissionGroupInfo>(mappedPermissionGroup);
        }

        [AuthorizeAspect(new string[] { AllPermissions.PermissionGroup_Create })]
        [ValidationAspect(typeof(CreatePermissionGroupInputValidator))]
        public async Task CreatePermissionGroup(CreatePermissionGroupInput input)
        {
            var newPermissionGroup = Mapper.Map<PermissionGroup>(input);
            await _permissionGroupRepository.InsertAsync(newPermissionGroup);
        }
      
        [AuthorizeAspect(new string[] { AllPermissions.PermissionGroup_Update })]
        [ValidationAspect(typeof(UpdatePermissionGroupInputValidator))]
        public async Task UpdatePermissionGroup(UpdatePermissionGroupInput input)
        {

            var checkPermissionGroup = await _permissionGroupRepository.GetAsync(input.Id);
            if (checkPermissionGroup == null)
            {
                throw new Exception($"{input.Id} nolu Id degeri bulunamadı");
            }
            Mapper.Map(input, checkPermissionGroup);
            await _permissionGroupRepository.UpdateAsync(checkPermissionGroup);
        }

        [AuthorizeAspect(new string[] { AllPermissions.PermissionGroup_Delete })]
        public async Task DeletePermissionGroup(int permissionGroupId)
        {
            var checkPermissionGroup = await _permissionGroupRepository.GetAsync(permissionGroupId);
            if (checkPermissionGroup == null)
            {
                throw new Exception($"{permissionGroupId} nolu Id degeri bulunamadı");
            }
            
            await _permissionGroupRepository.DeleteAsync(checkPermissionGroup.Id);
        }

        
    }
}
