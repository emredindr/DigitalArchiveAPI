using DigitalArchive.Business.Abstract;
using DigitalArchive.Core.DbModels;
using DigitalArchive.Core.Dto.Response;
using DigitalArchive.Core.Repositories;
using DigitalArchive.Entities.ViewModels.UserPermissionVM;
using Microsoft.EntityFrameworkCore;

namespace DigitalArchive.Business.Concreate
{
    public class UserPermissionAppService : IUserPermissionAppService
    {
        private readonly IRepository<Permission, int> _permissionRepository;
        private readonly IRepository<UserPermission, int> _userPermissionRepository;
        private readonly IRepository<PermissionGroup, int> _permissionGroupRepository;
        private readonly IRepository<User, int> _userRepository;

        public UserPermissionAppService
            (
            IRepository<UserPermission, int> userPermissionRepository,
            IRepository<Permission, int> permissionRepository,
            IRepository<PermissionGroup, int> permissionGroupRepository,
            IRepository<User, int> userRepository
            )
        {
            _permissionRepository = permissionRepository;
            _userPermissionRepository = userPermissionRepository;
            _permissionGroupRepository = permissionGroupRepository;
            _userRepository = userRepository;
        }

        public async Task CreateOrUpdateUserPermission(CreateOrUpdateUserPermissionInput input)
        {
            var checkUser = await _userRepository.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == input.UserId);
            if (checkUser == null)
            {
                throw new Exception("user bulunamadı ");
            }

            var userPermissionList = _userPermissionRepository.GetAllList(x => x.UserId == input.UserId);
            var userPermissionIdList = userPermissionList.Select(x => x.PermissionId).ToList();

            var selectedPermissionIdList = input.PermissionList.Select(x => x.PermissionId).ToList();

            //Silinecek Kayıtlar
            var differanceFromSelected = userPermissionIdList.Except(selectedPermissionIdList).ToList();

            //Eklenecek kayıtlar
            var differanceFromNotSelected = selectedPermissionIdList.Except(userPermissionIdList).ToList();

            foreach (var addItemId in differanceFromNotSelected)
            {
                await _userPermissionRepository.InsertAsync(new UserPermission
                {
                    UserId = input.UserId,
                    PermissionId = addItemId,
                });
            }
            foreach (var deleteItemId in differanceFromSelected)
            {

                var query = _userPermissionRepository.FirstOrDefault(x => x.PermissionId == deleteItemId && x.UserId == input.UserId);
                await _userPermissionRepository.RemoveAsync(query.Id);
            }
        }
        public async Task<ListResult<GetPermissionGroupAndPermissionList>> GetPermissionGroupAndPermission(int userId)
        {
            var checkUser = _userRepository.FirstOrDefault(x => !x.IsDeleted && x.Id == userId);
            if (checkUser == null)
            {
                throw new Exception("user bulunamadı ");
            }

            List<GetPermissionGroupAndPermissionList> result = new List<GetPermissionGroupAndPermissionList>();
            var permissionGroupList = await _permissionGroupRepository.GetAll().Where(x => !x.IsDeleted).ToListAsync();
            var userPermissionList = await _userPermissionRepository.GetAll().Where(x => x.UserId == userId).ToListAsync();

            foreach (var item in permissionGroupList)
            {
                var resultItem = new GetPermissionGroupAndPermissionList();
                resultItem.PermissionList = new List<PermissionAndUserInfo>();
                var permissionList = await _permissionRepository.GetAll().Where(x => !x.IsDeleted && x.PermissionGroupId == item.Id).ToListAsync();
                resultItem.PermissionGroupId = item.Id;
                resultItem.PermissionGroupName = item.Name;
                foreach (var childItem in permissionList)
                {
                    var userPermissionCheck = userPermissionList.Any(x => x.PermissionId == childItem.Id);
                    resultItem.PermissionList.Add(new PermissionAndUserInfo
                    {
                        PermissionId = childItem.Id,
                        PermissionName = childItem.Name,
                        IsChecked = userPermissionCheck,
                    });
                }
                result.Add(resultItem);
            }
            return new ListResult<GetPermissionGroupAndPermissionList>(result);
        }

        public async Task<List<Permission>> GetUserPermissions(int userId)
        {
            var result = from permission in _permissionRepository.GetAll()
                         join userPermission in _userPermissionRepository.GetAll() on permission.Id equals userPermission.PermissionId
                         where userPermission.UserId == userId
                         select permission;
            return await result.ToListAsync();
        }
    }




}
