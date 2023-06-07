using DigitalArchive.Core.DbModels;
using DigitalArchive.Core.Dto.Response;
using DigitalArchive.Entities.ViewModels.UserPermissionVM;

namespace DigitalArchive.Business.Abstract
{
    public interface IUserPermissionAppService
    {
        Task<ListResult<PermissionAndUserInfo>> GetUserPermissionList(int userId);
        Task<List<Permission>> GetUserPermissions(int userId);
        Task<ListResult<GetPermissionGroupAndPermissionList>> GetPermissionGroupAndPermission(int userId);

        Task CreateOrUpdateUserPermission(CreateOrUpdateUserPermissionInput input);
    }
}
