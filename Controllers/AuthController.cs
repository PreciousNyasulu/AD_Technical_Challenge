using Microsoft.AspNetCore.Mvc;
using NaLib.Models;
using NaLib.Services;

namespace NaLib.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    UserService _userService;
    public AuthController(ILogger<AuthController> logger,UserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpPost("login", Name = "login")]
    public IActionResult Post([FromBody] LoginPayload Body)
    {
        if (Body == null)
        {
            return BadRequest();
        }

        LoginStatus Status = _userService.ConfirmUser(new Users{Email = Body.Username, UserName = Body.Username, Password = Body.Password});

        switch (Status)
        {
            case LoginStatus.IncorrectPassword:
                return BadRequest(new ResponseMessage { Message = "Wrong Password" });
            case LoginStatus.NotFound :
                return NotFound(new ResponseMessage { Message = "Account not found" });
            case LoginStatus.Success :
                return Ok(new ResponseMessage { Message = "Logged in successfully" });
            default:
                return BadRequest(new ResponseMessage{Message = "Failed to login"});
        }
        
    }

    [HttpPost("register", Name = "register")]
    public IActionResult Register([FromBody] Users user)
    {
        if (user == null)
        {
            return BadRequest(new ResponseMessage{Message = "Missing fields"});
        }
        

        if (_userService.UserExists(user))
        {
            return Conflict(new ResponseMessage{Message = "User already exists"});
        }

        _userService.AddUser(user);
        return CreatedAtRoute("register", new { id = user.Id }, user);
    }

}