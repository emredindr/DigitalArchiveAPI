using DigitalArchive.Business.Abstract;
using DigitalArchive.Core.Dto.Response;
using DigitalArchive.Entities.ViewModels.UserCategoryVM;
using Microsoft.AspNetCore.Mvc;

namespace DigitalArchive.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UserCategoryController : BaseController
{
    private readonly IUserCategoryAppService _userCategoryAppService;
    public UserCategoryController(IUserCategoryAppService userCategoryAppService)
    {
        _userCategoryAppService = userCategoryAppService;
    }
    
    [HttpGet("GetCategoryTypeAndCategoryList")]
    public async Task<ListResult<CategoryAndUserInfo>> GetCategoryTypeAndCategoryList(int userId)
    {
        return await _userCategoryAppService.GetCategoryAndUserList(userId);
    }

    [HttpPost("CreateOrUpdateUserCategory")]
    public async Task CreateOrUpdateUserCategory(CreateOrUpdateUserCategoryInput input)
    {
        await _userCategoryAppService.CreateOrUpdateUserCategory(input);
    }
}
