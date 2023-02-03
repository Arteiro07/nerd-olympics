using Data.Models;
using Microsoft.AspNetCore.Mvc;
using NerdOlympicsAPI.Interfaces;

namespace NerdOlympics.Controllers;

[ApiController]
[Route("competitions")]
public class CompetitionController : Controller
{
    private readonly ILogger<CompetitionController> _logger;
    private readonly ICompetitionsService _competitionsService;

    public CompetitionController(ILogger<CompetitionController> logger, ICompetitionsService competitionsService)
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
