using NerdOlympics.Data.Models;

namespace NerdOlympics.Data.Interfaces
{
    public interface IFactoryRepository
    {
        Task<List<Record>> GetCompetitionRecordsWithUsers(int competitionId);
    }
}