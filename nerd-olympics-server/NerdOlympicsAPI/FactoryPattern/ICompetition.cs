using NerdOlympics.API.FactoryPattern.Models;
using NerdOlympics.Data.Enum.Competitions;
using NerdOlympics.Data.Models;

namespace NerdOlympics.API.Factory
{
    public interface ICompetition
    {
        ClassificationType classificationType { get; }
        Task<List<ScoreLine>> Leaderboard();
    }
}
