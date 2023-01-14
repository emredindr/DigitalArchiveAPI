using DigitalArchive.Business.Abstract;
using DigitalArchive.Core.Dto.Response;
using DigitalArchive.Entities.ViewModels.UserDocumentVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalArchive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UserDocumentController : BaseController
    {
        private readonly IUserDocumentAppService _userDocumentAppService;
        public UserDocumentController(IUserDocumentAppService userDocumentAppService)
        {
            _userDocumentAppService = userDocumentAppService;
        }

        [HttpGet("GetAllUserDocumentByPage")]
        public async Task<PagedResult<GetAllUserDocumentInfo>> GetAllUserDocumentByPage([FromQuery] GetAllUserDocumentInput input)
        {
            return await _userDocumentAppService.GetAllUserDocumentByPage(input);
        }

        [HttpGet("GetUserDocumentById")]
        public async Task<GetAllUserDocumentInfo> GetUserDocumentById(int userDocumentId)
        {
            return await _userDocumentAppService.GetUserDocumentById(userDocumentId);
        }
        [HttpPost("CreateUserDocument")]
        public async Task CreateUserDocument(CreateUserDocumentInput input)
        {
            await _userDocumentAppService.CreateUserDocument(input);
        }
        [HttpPost("UpdateUserDocument")]
        public async Task UpdateUserDocument(UpdateUserDocumentInput input)
        {
            await _userDocumentAppService.UpdateUserDocument(input);
        }
        
        [HttpDelete("DeleteUserDocument")]
        public async Task DeleteUserDocument(int userDocumentId)
        {
            await _userDocumentAppService.DeleteUserDocument(userDocumentId);
        }



    }
}
