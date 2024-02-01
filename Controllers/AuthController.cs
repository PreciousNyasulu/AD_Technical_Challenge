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

    [HttpGet(Name = "login")]
    public IActionResult Get()
    {
        
    }
       
}
