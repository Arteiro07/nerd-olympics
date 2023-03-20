using NerdOlympics.API.FactoryPattern.Models;
using NerdOlympics.Data.Enum.Competitions;
using NerdOlympics.Data.Interfaces;
using NerdOlympics.Data.Models;

namespace NerdOlympics.API.Factory
{
    public interface ICompetition
    {
        ClassificationType ClassificationType { get; }
        int CompetitionID { get; }
        public IFactoryRepository _repository { get; }
        Task<List<ScoreLine>> Leaderboard();
        Task<List<ScoreLine>> UserLeaderboard(int userId);
    }
}
