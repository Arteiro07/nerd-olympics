using Data.Models;

namespace Data.Interfaces
{
    public interface ICompetitionRepository
    {
        Task<List<Competition>> GetCompetitions();
        Task<Competition?> CreateCompetition(Competition competition);
    }
}
