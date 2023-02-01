using Data.Models;
using Microsoft.AspNetCore.Mvc;
using NerdOlympicsAPI.Interfaces;

namespace NerdOlympics.Controllers;

[ApiController]
[Route("competitions")]
public class CompetitionsController : Controller
{
    private readonly ILogger<CompetitionsController> _logger;
    private readonly ICompetitionsService _competitionsService;

    public CompetitionsController(ILogger<CompetitionsController> logger, ICompetitionsService competitionsService)
    {
        _logger = logger;
        _competitionsService = competitionsService;
    }

    [HttpGet]
    [Route("")]
    public async Task<List<Competition>> GetCompetitions()
    {
        return await _competitionsService.GetCompetitions();
    }
}
