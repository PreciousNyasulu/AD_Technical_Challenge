using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NaLib.Models;
using NaLib.Services;

namespace NaLib.Controllers;

[ApiController]
[Route("[controller]")]
public class MemberController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    LibraryMemberService _MemberService;
    public MemberController(ILogger<AuthController> logger,LibraryMemberService MemberService)
    {
        _logger = logger;
        _MemberService = MemberService;
    }

    [HttpPost("add", Name = "Add_MemberResource")]
    public IActionResult Post([FromBody] LibraryMember Body)
    {
        if (Body == null)
        {
            return BadRequest();
        }

        if (_MemberService.MemberExists(Body))
        {
            return Conflict(new ResponseMessage{Message = "Member already exist"});
        }

        _MemberService.AddMember(Body);
        return Ok(new ResponseMessage{Message = "Member added"});
    }
}