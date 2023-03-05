using NerdOlympics.API.Factory;
using NerdOlympics.Data.Models;

namespace NerdOlympics.API.FactoryPattern.Models.CompetitionTypes
{
    public class TimedCompetition : ICompetition
    {
        public async Task<List<ScoreLine>> Leaderboard() 
        {
            return new List<ScoreLine>();
        }
    }
}
