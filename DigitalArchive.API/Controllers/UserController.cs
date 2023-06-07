using DigitalArchive.Business.Abstract;
using DigitalArchive.Core.Dto.Response;
using DigitalArchive.Entities.ViewModels.UserVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalArchive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : BaseController
    {

        private readonly IUserAppService _userAppService;
        private readonly ILogger<UserController> _logger;
        public UserController
            (
            IUserAppService userAppService,
            ILogger<UserController> logger
            )
        {
            _userAppService = userAppService;
            _logger = logger;
        }

        [HttpGet("GetUserById")]
        public async Task<GetAllUserInfo> GetUserById(int userId)
        {
            return await _userAppService.GetUserById(userId);
        }

        [HttpGet("GetCurrentUserInfo")]
        public async Task<GetAllUserInfo> GetCurrentUserInfo()
        {
            return await _userAppService.GetCurrentUserInfo();
        }

        [HttpGet("GetUserList")]
        public async Task<ListResult<GetAllUserInfo>> GetUserList([FromQuery] GetAllUserInput input)
        {
            return await _userAppService.GetUserList(input);
        }

        [HttpGet("GetAllUsersByPage")]
        public async Task<PagedResult<GetAllUserInfo>> GetAllUsersByPage([FromQuery] GetAllUserInput getAllUserInput)
        {
            _logger.Log(LogLevel.Information, "Selammm");
            return await _userAppService.GetAllUsersByPage(getAllUserInput);
        }

        [HttpPost("CreateUser")]
        public async Task CreateUser(CreateUserInput createUserInput)
        {
            await _userAppService.CreateUser(createUserInput);
        }

        [HttpPost("UpdateUser")]
        public async Task UpdateUser(UpdateUserInput updateUserInput)
        {
            await _userAppService.UpdateUser(updateUserInput);
        }

        [HttpPost("UpdateCurrentUserInfo")]
        public async Task UpdateCurrentUserInfo(UpdateUserInput updateUserInput)
        {
            await _userAppService.UpdateCurrentUserInfo(updateUserInput);
        }

        [HttpDelete("DeleteUser")]
        public async Task DeleteUser(int userId)
        {
            await _userAppService.DeleteUser(userId);
        }
    }
}
