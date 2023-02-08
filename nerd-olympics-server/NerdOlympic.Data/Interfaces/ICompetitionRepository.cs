using Data.Models;

namespace Data.Interfaces
{
    public interface ICompetitionRepository
    {
        Task<List<Competition>> GetCompetitions();
        Task<Competition?> CreateCompetition(Competition competition);
        Task<bool> UserOwnsCompetition(string userId, int competitionId);
        Task<Competition?> UpdateCompetition(Competition competition);
    }
}
