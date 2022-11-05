using DigitalArchive.Core.Dto.Response;
using DigitalArchive.Entities.ViewModels.PermissionVM;
using DigitalArchive.Entities.ViewModels.PermissionGroupVM;

namespace DigitalArchive.Business.Abstract
{
    public interface IPermissionGroupAppService
    {
        Task<PagedResult<GetAllPermissionGroupInfo>> GetAllPermissionGroupByPage(GetAllPermissionGroupInput input);
        Task<GetAllPermissionGroupInfo> GetPermissionGroupById(int permissionGroupId);
        Task<ListResult<GetAllPermissionGroupInfo>> GetPermissionGroupList();
        Task CreatePermissionGroup(CreatePermissionGroupInput input);
        Task UpdatePermissionGroup(UpdatePermissionGroupInput input);
        Task DeletePermissionGroup(int permissionGroupId);
    }
}
