using DigitalArchive.Business.Abstract;
using DigitalArchive.Core.DbModels;
using DigitalArchive.Core.Dto.Response;
using DigitalArchive.Entities.ViewModels.PermissionVM;
using DigitalArchive.Entities.ViewModels.UserPermissionVM;
using Microsoft.AspNetCore.Mvc;

namespace DigitalArchive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserPermissionController : ControllerBase
    {
        private readonly IUserPermissionAppService _userPermissionAppService;
        public UserPermissionController(IUserPermissionAppService userPermissionAppService)
        {
            _userPermissionAppService = userPermissionAppService;
        }

        [HttpGet("GetUserPermissionList")]
        public async Task<ListResult<PermissionAndUserInfo>> GetUserPermissionList(int userId)
        {
            return await _userPermissionAppService.GetUserPermissionList(userId);
        }

        [HttpGet("GetPermissionGroupAndPermission")]
        public async Task<ListResult<GetPermissionGroupAndPermissionList>> GetPermissionGroupAndPermission(int userId)
        {
            return await _userPermissionAppService.GetPermissionGroupAndPermission(userId);
        }

        [HttpPost("CreateOrUpdateUserPermission")]
        public async Task CreateOrUpdateUserPermission(CreateOrUpdateUserPermissionInput input)
        {
            await _userPermissionAppService.CreateOrUpdateUserPermission(input);
        }
    }
}
