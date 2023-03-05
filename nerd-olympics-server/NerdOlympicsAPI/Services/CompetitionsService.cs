using NerdOlympics.Data.Models;
using Microsoft.AspNetCore.Mvc;
using NerdOlympics.Data.Interfaces;
using NerdOlympicsAPI.Interfaces;
<<<<<<< HEAD
using NerdOlympics.API.Factory;
using NerdOlympics.API.FactoryPattern;
=======
using NerdOlympics.Data.Models.ErrorHandling;
using System.Net;
>>>>>>> main

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

        public async Task<IActionResult> GetCompetitionLeaderBoard(int competitionId)
        {
            Competition c = await _competitionRepository.GetCompetition(competitionId)?;

            ICompetition competition = CompetitionFactory.GetCompetition(c.MeasurementType);

            return new OkObjectResult(await competition.Leaderboard());
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

        public async Task<IActionResult> CompetitionNameExists(string competitionName)
        {
            return new OkObjectResult(await _competitionRepository.CompetitionNameExists(competitionName));
        }
    }
}
