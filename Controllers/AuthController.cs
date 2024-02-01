using Microsoft.AspNetCore.Mvc;

namespace NaLib.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }

    [HttpPost("login",Name = "login")]
    public IActionResult Post([FromBody] LoginPayload Body)
    {
        if (Body == null)
        {
            return BadRequest();
        }

        UserRepository abstractInterface;

        abstractInterface = new UserRepository();

        return Ok(abstractInterface.GetUsers());
    }

    [HttpPost("register",Name ="register")]
    public IActionResult Post([FromBody] Users User)
    {
        
        return Ok();
    }
       
}