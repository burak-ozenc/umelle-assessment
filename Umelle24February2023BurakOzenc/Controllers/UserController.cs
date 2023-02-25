using Microsoft.AspNetCore.Mvc;
using Umelle24February2023BurakOzenc.Common;
using Umelle24February2023BurakOzenc.Services;

namespace Umelle24February2023BurakOzenc.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser(UserDto request)
    {
        var result = await _userService.ValidateRequest(request);

        if (!result.status)
            return BadRequest(result.errorCodes);
        
        var token = await _userService.CreateUser(request);
        
        return Ok(token);
    }
}