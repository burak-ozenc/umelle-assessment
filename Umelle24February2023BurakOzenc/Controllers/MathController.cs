using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Umelle24February2023BurakOzenc.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class MathController : ControllerBase
{
    [HttpGet("GetRandomNumbers")]
    public async Task<IActionResult> GetRandomNumbers()
    {
        var list = new List<int>();
        Random random = new Random();
        list.Add(random.Next(0,100));
        list.Add(random.Next(0,100));
        list.Add(random.Next(0,100));
        list.Add(random.Next(0,100));
        
        
        return Ok(list);
    }
}