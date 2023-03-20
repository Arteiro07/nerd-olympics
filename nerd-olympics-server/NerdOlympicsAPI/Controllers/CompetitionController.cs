using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NerdOlympics.Data.Enum.Security;
using NerdOlympics.Data.Models;
using NerdOlympics.Data.Models.ErrorHandling;
using NerdOlympicsAPI.Interfaces;

namespace NerdOlympics.Controllers;

[ApiController]
[Route("competitions")]
public class CompetitionController : Controller
{
    private readonly ICompetitionsService _competitionsService;

    public CompetitionController(ICompetitionsService competitionsService)
    {
        _competitionsService = competitionsService;
    }

    [HttpGet]
    [Route("all")]
    [ProducesResponseType(typeof(IActionResult), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    [ProducesResponseType(typeof(ErrorResponse), 500)]
    public async Task<IActionResult> GetCompetitions()
    {
        return await _competitionsService.GetCompetitions();
    }
    
    [HttpGet]
    [Route("")]
    [ProducesResponseType(typeof(IActionResult), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    [ProducesResponseType(typeof(ErrorResponse), 500)]
    public async Task<IActionResult> GetCompetition(int competitionId)
    {
        return await _competitionsService.GetCompetition(competitionId);
    }

    [HttpGet]
    [Route("leaderboard")]
    //[Authorize(Policies.Authenticated)]
    public async Task<IActionResult> GetCompetitionLeaderboard(int competitionId)
    {
        return await _competitionsService.GetCompetitionLeaderBoard(competitionId);
    }

    [HttpGet]
    [Route("user-leaderboard")]
    //[Authorize(Policies.Authenticated)]
    public async Task<IActionResult> GetCompetitionUserLeaderboard(int competitionId, int userId)
    {
        return await _competitionsService.GetCompetitionUserLeaderBoard(competitionId, userId);
    }

    [HttpGet]
    [Route("validation")]
    [ProducesResponseType(typeof(IActionResult), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    [ProducesResponseType(typeof(ErrorResponse), 500)]
    public async Task<IActionResult> CompetitionNameExists(string competitionName)
    {
        return await _competitionsService.CompetitionNameExists(competitionName);
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(typeof(IActionResult), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    [ProducesResponseType(typeof(ErrorResponse), 500)]
    [Authorize(Policies.Authenticated)]
    public async Task<IActionResult> CreateCompetition([FromBody] Competition competition)
    {
        return await _competitionsService.CreateCompetition(competition);
    }

    [HttpPut]
    [Route("")]
    [ProducesResponseType(typeof(IActionResult), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    [ProducesResponseType(typeof(ErrorResponse), 500)]
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
