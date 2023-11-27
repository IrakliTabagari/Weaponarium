using Microsoft.AspNetCore.Mvc;
using Server.Api.Models.Login.Request;
using Server.Domain.Interfaces.Services;

namespace Server.Api.Controllers;

[ApiController]
[Route("[controller]/")]
public class LoginController : ControllerBase
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost(nameof(LoginWithEmailAndPassword))]
    // [Authorize(Permissions.Private.Users.Create)]
    public async Task<IActionResult> LoginWithEmailAndPassword(LoginWithEmailAndPasswordRequestModel request)
    {
        var loginResult = await _loginService.LoginWithUserNameAndPassword(request.Email, request.Password);

        return loginResult.Match<IActionResult>(
            result =>
            {
                return Ok(result);
            },
            exception =>
            {
                return BadRequest(exception.Message);
            });
    }
}