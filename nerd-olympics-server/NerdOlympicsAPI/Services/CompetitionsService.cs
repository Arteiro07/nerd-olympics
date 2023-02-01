using Data.Interfaces;
using Data.Models;
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

        public async Task<List<Competition>> GetCompetitions()
        {
            return await _competitionRepository.GetCompetitions();
        }
    }
}
