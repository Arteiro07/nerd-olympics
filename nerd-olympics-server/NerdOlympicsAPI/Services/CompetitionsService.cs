using NerdOlympics.Data.Models;
using Microsoft.AspNetCore.Mvc;
using NerdOlympics.Data.Interfaces;
using NerdOlympicsAPI.Interfaces;
using NerdOlympics.Data.Models.ErrorHandling;
using System.Net;

namespace NerdOlympicsAPI.Services
{
    public class CompetitionsService : ICompetitionsService
    {
        private readonly ICompetitionRepository _competitionRepository;

        public CompetitionsService(ICompetitionRepository competitionRepository) 
        {
            _competitionRepository = competitionRepository;
        }

        public async Task<IActionResult> GetCompetitions()
        {
            return new OkObjectResult(await _competitionRepository.GetCompetitions());
        }

        public async Task<IActionResult> GetCompetition(int competitionId)
        {
            return new OkObjectResult(await _competitionRepository.GetCompetition(competitionId));
        }

        public async Task<IActionResult> CreateCompetition(Competition competition)
        {
            return new OkObjectResult(await _competitionRepository.CreateCompetition(competition));
        }

        public async Task<IActionResult> UpdateCompetition(Competition competition, string userId)
        {
            if(competition == null || !await _competitionRepository.UserOwnsCompetition(userId, competition.CompetitionId))            
                throw new CustomException((int)HttpStatusCode.NotFound, ErrorMessage.USER_DOES_NOT_OWN_COMPETITION);
            
            return new OkObjectResult(await _competitionRepository.UpdateCompetition(competition));
        }
    }
}
