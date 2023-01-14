using DigitalArchive.Business.Abstract;
using DigitalArchive.Core.Aspects.AutoFac.Authorize;
using DigitalArchive.Core.Authorization;
using DigitalArchive.Core.DbModels;
using DigitalArchive.Core.Dto.Response;
using DigitalArchive.Core.Extensions.Linq;
using DigitalArchive.Core.Repositories;
using DigitalArchive.Entities.ViewModels.CategoryTypeVM;
using Microsoft.EntityFrameworkCore;

namespace DigitalArchive.Business.Concreate
{
    public class CategoryTypeAppService : BaseAppService, ICategoryTypeAppService
    {
        private readonly IRepository<CategoryType, int> _categoryTypeRepository;
        public CategoryTypeAppService(IRepository<CategoryType, int> categoryTypeRepository)
        {
            _categoryTypeRepository = categoryTypeRepository;
        }

        [AuthorizeAspect(new string[] { AllPermissions.CategoryType_List })]
        public async Task<ListResult<GetAllCategoryTypeInfo>> GetCategoryTypeList()
        {
            var query = await _categoryTypeRepository.GetAll().Where(x=>!x.IsDeleted).ToListAsync();
            
            var newCategoryTypes = Mapper.Map<List<GetAllCategoryTypeInfo>>(query);

            return new ListResult<GetAllCategoryTypeInfo>(newCategoryTypes);
        }
        
        [AuthorizeAspect(new string[] { AllPermissions.CategoryType_List })]
        public async Task<PagedResult<GetAllCategoryTypeInfo>> GetAllCategoryTypeByPage(GetAllCategoryTypeInput input)
        {
            var query = _categoryTypeRepository.GetAll().Where(x => !x.IsDeleted);

            query = query.WhereIf(!string.IsNullOrEmpty(input.SearchText), x => x.Name.Contains(input.SearchText));

            var totalCategoryTypeCount = await query.CountAsync();

            var categoryTypes = await query.PageBy(input.SkipCount, input.MaxResultCount).ToListAsync();

            var newCategoryTypes = Mapper.Map<List<GetAllCategoryTypeInfo>>(categoryTypes);

            return new PagedResult<GetAllCategoryTypeInfo>(totalCategoryTypeCount, newCategoryTypes);
        }

        [AuthorizeAspect(new string[] { AllPermissions.CategoryType_Create })]
        public async Task CreateCategoryType(CreateCategoryTypeInput input)
        {
            var newCategoryType =Mapper.Map<CategoryType>(input);
            await _categoryTypeRepository.InsertAsync(newCategoryType);
        }
        
        [AuthorizeAspect(new string[] { AllPermissions.CategoryType_Update })]
        public async Task UpdateCategoryType(UpdateCategoryTypeInput input)
        {
            var checkCategoryType = await _categoryTypeRepository.GetAsync(input.Id);
            if (checkCategoryType == null)
            {
                throw new Exception($"{input.Id} nolu Id degeri bulunamadı");
            }
            Mapper.Map(input, checkCategoryType);
            await _categoryTypeRepository.UpdateAsync(checkCategoryType);
        }
       
        [AuthorizeAspect(new string[] { AllPermissions.CategoryType_Delete })]
        public async Task DeleteCategoryType(int categoryTypeId)
        {
            var checkCategoryType = await _categoryTypeRepository.GetAsync(categoryTypeId);
            if (checkCategoryType == null)
            {
                throw new Exception($"{categoryTypeId} nolu Id degeri bulunamadı");
            }
            await _categoryTypeRepository.DeleteAsync(checkCategoryType.Id);
        }
    }
}
