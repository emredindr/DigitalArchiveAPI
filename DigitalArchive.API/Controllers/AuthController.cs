using DigitalArchive.Business.Abstract;
using DigitalArchive.Entities.UserVM;
using Microsoft.AspNetCore.Mvc;

namespace DigitalArchive.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{

    private readonly IUserAppService _userAppService;
    public AuthController(IUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    [HttpPost("Authenticate")]
    public async Task<UserLoginOutput> Authenticate(UserLoginInput input)
    {
        var userInfo = await _userAppService.Login(input);
        return userInfo;
    }
}
