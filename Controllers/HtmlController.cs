using Microsoft.AspNetCore.Mvc;

namespace NaLib.Controllers;

[ApiController]
[Route("[controller]")]
public class HtmlController : ControllerBase
{

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<HtmlController> _logger;

    public HtmlController(ILogger<HtmlController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "/")]
    public IActionResult Get()
    {
       // Get the path to the HTML file
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Pages", "index.html");

        // Check if the file exists
        if (!System.IO.File.Exists(filePath))
        {
            _logger.LogError($"File not found in the specified directory({filePath})");            
            return NotFound();
        }
        // Read the contents of the HTML file
        var htmlContent = System.IO.File.ReadAllText(filePath);

        // Return the HTML Page
        return Content(htmlContent, "text/html");
    }
}
