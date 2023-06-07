using DigitalArchive.Core.Dto.Response;
using DigitalArchive.Entities.ViewModels.PermissionVM;

namespace DigitalArchive.Business.Abstract
{
    public interface IPermissionAppService
    {
        Task<PagedResult<GetAllPermissionInfo>> GetAllPermissionByPage(GetAllPermissionInput input);
        Task<ListResult<GetAllPermissionInfo>> GetPermissionList();
        Task<ListResult<GetAllPermissionInfoByGroup>> GetPermissionListByGroup();
        Task<GetAllPermissionInfo> GetPermissionById(int permissionId);

        Task CreatePermission(CreatePermissionInput input);
        Task UpdatePermission(UpdatePermissionInput input);
        Task DeletePermission(int permissionId);
    }
}
