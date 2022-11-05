using DigitalArchive.Business.Abstract;
using DigitalArchive.Business.ValidationRules.FluentValidation.PermissionGroup;
using DigitalArchive.Core.Aspects.AutoFac.Validation;
using DigitalArchive.Core.Dto.Response;
using DigitalArchive.Entities.ViewModels.PermissionGroupVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalArchive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionGroupController : BaseController
    {
        private readonly IPermissionGroupAppService _permissionGroupAppService;
        public PermissionGroupController(IPermissionGroupAppService permissionGroupAppService)
        {
            _permissionGroupAppService = permissionGroupAppService;
        }
        [HttpGet("GetPermissionGroupById")]
        public async Task<GetAllPermissionGroupInfo> GetPermissionGroupById(int permissionGroupId)
        {
            return await _permissionGroupAppService.GetPermissionGroupById(permissionGroupId);
        }
       
        [HttpGet("GetAllPermissionGroupByPage")]
        public async Task<PagedResult<GetAllPermissionGroupInfo>> GetAllPermissionGroupByPage([FromQuery] GetAllPermissionGroupInput input)
        {
            return await _permissionGroupAppService.GetAllPermissionGroupByPage(input);
        }
        
        [HttpGet("GetPermissionGroupList")]
        public async Task<ListResult<GetAllPermissionGroupInfo>> GetPermissionGroupList()
        {
            return await _permissionGroupAppService.GetPermissionGroupList();
        }
        
        [ValidationAspect(typeof(CreatePermissionGroupInputValidator))]
        [HttpPost("CreatePermissionGroup")]
        public async Task CreatePermissionGroup(CreatePermissionGroupInput input)
        {
            await _permissionGroupAppService.CreatePermissionGroup(input);
        }
        
        [ValidationAspect(typeof(UpdatePermissionGroupInputValidator))]
        [HttpPost("UpdatePermissionGroup")]
        public async Task UpdatePermissionGroup(UpdatePermissionGroupInput input)
        {
            await _permissionGroupAppService.UpdatePermissionGroup(input);
        }
        
        [HttpDelete("DeletePermissionGroup")]
        public async Task DeletePermissionGroup(int permissionGroupId)
        {
            await _permissionGroupAppService.DeletePermissionGroup(permissionGroupId);
        }
    }
}
