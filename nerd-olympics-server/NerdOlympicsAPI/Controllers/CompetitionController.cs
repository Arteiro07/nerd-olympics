using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using NerdOlympicsAPI.Interfaces;
using NerdOlympicsData.Enum;

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
    [Route("all")]
    public async Task<IActionResult> GetCompetitions()
    {
        return await _competitionsService.GetCompetitions();
    }

    [HttpPost]
    [Route("")]
    [Authorize(Policies.Authenticated)]
    public async Task<IActionResult> CreateCompetition([FromBody] Competition competition)
    {
        return await _competitionsService.CreateCompetition(competition);
    }

    [HttpPut]
    [Route("")]
    [Authorize(Policies.Authenticated)]
    public async Task<IActionResult> UpdateCompetition([FromBody] Competition competition)
    {
        var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authenticated)?.Value;

        if(userId == null) 
        { 
            return Unauthorized();
        }

        return await _competitionsService.UpdateCompetition(competition, userId);
    }

}
