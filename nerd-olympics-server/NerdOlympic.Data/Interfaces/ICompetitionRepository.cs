using NerdOlympics.Data.Models;

namespace NerdOlympics.Data.Interfaces
{
    public interface ICompetitionRepository
    {
        Task<List<Competition>> GetCompetitions();
        Task<Competition> GetCompetition(int competitionId);
        Task<Competition> CreateCompetition(Competition competition);
        Task<bool> UserOwnsCompetition(string userId, int competitionId);
        Task<Competition> UpdateCompetition(Competition competition);
        Task<bool> CompetitionExists(int competitionId);
    }
}
