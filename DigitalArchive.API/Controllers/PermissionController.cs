using DigitalArchive.Business.Abstract;
using DigitalArchive.Core.Dto.Response;
using DigitalArchive.Entities.ViewModels.PermissionVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalArchive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PermissionController : BaseController
    {
        private readonly IPermissionAppService _permissionAppService;
        public PermissionController(IPermissionAppService permissionAppService)
        {
            _permissionAppService = permissionAppService;
        }
        
        [HttpGet("GetPermissionById")]
        public async Task<GetAllPermissionInfo> GetPermissionById(int permissionId)
        {
            return await _permissionAppService.GetPermissionById(permissionId);
        }

        [HttpGet("GetPermissionList")]
        public async Task<ListResult<GetAllPermissionInfo>> GetPermissionList() 
        { 
            return await _permissionAppService.GetPermissionList();
        }

        [HttpGet("GetAllPermissionByPage")]
        public async Task<PagedResult<GetAllPermissionInfo>> GetAllPermissionByPage([FromQuery] GetAllPermissionInput input)
        {
            return await _permissionAppService.GetAllPermissionByPage(input);
        }

        [HttpPost("CreatePermission")]
        public async Task CreatePermission(CreatePermissionInput input)
        {
            await _permissionAppService.CreatePermission(input);
        }

        [HttpPost("UpdatePermission")]
        public async Task UpdatePermission(UpdatePermissionInput input)
        {
            await _permissionAppService.UpdatePermission(input);
        }

        [HttpDelete("DeletePermission")]
        public async Task DeletePermission(int id)
        {
            await _permissionAppService.DeletePermission(id);
        }
    }
}
