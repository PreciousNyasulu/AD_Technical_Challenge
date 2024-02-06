using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NaLib.Models;
using NaLib.Services;

namespace NaLib.Controllers;

[ApiController]
[Route("[controller]")]
public class ResourceController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    LibraryResourceService _ResourceService;
    public ResourceController(ILogger<AuthController> logger,LibraryResourceService ResourceService)
    {
        _logger = logger;
        _ResourceService = ResourceService;
    }

    [HttpPost("add", Name = "Add_Resource")]
    public IActionResult Post([FromBody] LibraryResource Body)
    {
        if (Body == null)
        {
            return BadRequest();
        }

        if (_ResourceService.ResourceExists(Body))
        {
            return Conflict(new ResponseMessage{Message = "Resource already exist"});
        }

        _ResourceService.AddResource(Body);
        return Ok(new ResponseMessage{Message = "Resource added"});
    }
    
    [HttpGet("GetAll", Name = "Get_Resources")]
    public IActionResult GetAllResources()
    {
        return Ok(_ResourceService.GetAllResources());
    }
}