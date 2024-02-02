using Microsoft.AspNetCore.Mvc;

namespace NaLib.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
 UserRepository abstractInterface = new UserRepository();
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
        return Ok(abstractInterface.GetAll());
    }

    [HttpPost("register",Name ="register")]
    public IActionResult Post([FromBody] Users User)
    {
        if (User == null)
        {
            BadRequest("Missing fields");
        }
        abstractInterface.Add(User);
        return Ok();
    }
       
}