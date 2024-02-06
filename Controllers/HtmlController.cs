using Microsoft.AspNetCore.Mvc;
using NaLib.Services;

namespace NaLib.Controllers;

[ApiController]
[Route("/")]
public class HtmlController : ControllerBase
{
    private readonly ILogger<HtmlController> _logger;
    private readonly HtmlService _HtmlService;

    public HtmlController(ILogger<HtmlController> logger,HtmlService htmlService)
    {
        _logger = logger;
        _HtmlService = htmlService;
    }

    [HttpGet(Name = "/")]
    public IActionResult Get()
    {
        string FileName = "index.html";

        if (!_HtmlService.FileExists(FileName))
        {
            _logger.LogError($"File not found in the pages directory");            
            return NotFound();
        }
        var htmlContent = _HtmlService.ServeFile(FileName);

        return Content(htmlContent, "text/html");
    }

    [HttpGet("register", Name = "RegisterPage")]
    public IActionResult GetRegisterPage()
    {
        string FileName = "Register.html";

        if (!_HtmlService.FileExists(FileName))
        {
            _logger.LogError($"File not found in the pages directory");            
            return NotFound();
        }
        var htmlContent = _HtmlService.ServeFile(FileName);

        return Content(htmlContent, "text/html");
    }
    
    [HttpGet("home", Name = "HomePage")]
    public IActionResult GetHomePage()
    {
        string FileName = "Home.html";

        if (!_HtmlService.FileExists(FileName))
        {
            _logger.LogError($"File not found in the pages directory");            
            return NotFound();
        }
        var htmlContent = _HtmlService.ServeFile(FileName);

        return Content(htmlContent, "text/html");
    }
    
    [HttpGet("checkin-out", Name = "Checkin-outPage")]
    public IActionResult GetcheckInOut()
    {
        string FileName = "Check_in_out.html";

        if (!_HtmlService.FileExists(FileName))
        {
            _logger.LogError($"File not found in the pages directory");            
            return NotFound();
        }
        var htmlContent = _HtmlService.ServeFile(FileName);

        return Content(htmlContent, "text/html");
    }
    
    [HttpGet("resource", Name = "resource_page")]
    public IActionResult GetResourcePage()
    {
        string FileName = "AddResource.html";

        if (!_HtmlService.FileExists(FileName))
        {
            _logger.LogError($"File not found in the pages directory");            
            return NotFound();
        }
        var htmlContent = _HtmlService.ServeFile(FileName);

        return Content(htmlContent, "text/html");
    }
    
    [HttpGet("/ViewResources", Name = "view_resources_page")]
    public IActionResult ViewResources()
    {
        string FileName = "ViewResources.html";

        if (!_HtmlService.FileExists(FileName))
        {
            _logger.LogError($"File not found in the pages directory");            
            return NotFound();
        }
        var htmlContent = _HtmlService.ServeFile(FileName);

        return Content(htmlContent, "text/html");
    }
    
    [HttpGet("/AddMember", Name = "add_member_page")]
    public IActionResult AddMember()
    {
        string FileName = "AddMember.html";

        if (!_HtmlService.FileExists(FileName))
        {
            _logger.LogError($"File not found in the pages directory");            
            return NotFound();
        }
        var htmlContent = _HtmlService.ServeFile(FileName);

        return Content(htmlContent, "text/html");
    }
}
