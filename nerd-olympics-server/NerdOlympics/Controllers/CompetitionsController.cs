using Microsoft.AspNetCore.Mvc;
namespace NerdOlympics.Controllers;

[ApiController]
[Route("competitions")]
public class CompetitionsController : Controller
{
    private readonly ILogger<CompetitionsController> _logger;

    public CompetitionsController(ILogger<CompetitionsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("echo")]
    public string Echo(string input)
    {
        return input;
    }
}
