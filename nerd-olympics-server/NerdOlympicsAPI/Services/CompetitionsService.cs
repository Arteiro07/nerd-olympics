using Data.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using NerdOlympicsAPI.Interfaces;

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

        public async Task<IActionResult> CreateCompetition(Competition competition)
        {
            return new OkObjectResult(await _competitionRepository.CreateCompetition(competition));
        }

        public async Task<IActionResult> UpdateCompetition(Competition competition, string userId)
        {
            if(competition == null || !await _competitionRepository.UserOwnsCompetition(userId, competition.CompetitionId))
            {
                return new UnauthorizedObjectResult("User does not own competition");
            }

            Competition? updatedCompetition = await _competitionRepository.UpdateCompetition(competition);

            if (updatedCompetition == null)
            {
                throw new Exception("Error updating competition");
            }

            return new OkObjectResult(updatedCompetition);
        }
    }
}
