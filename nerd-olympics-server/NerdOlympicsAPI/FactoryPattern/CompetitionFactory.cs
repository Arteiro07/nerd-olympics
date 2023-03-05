using NerdOlympics.API.Factory;
using NerdOlympics.API.FactoryPattern.Models.CompetitionTypes;
using NerdOlympics.API.Interfaces;
using NerdOlympics.Data.Enum.Competitions;
using NerdOlympics.Data.Interfaces;
using NerdOlympics.Data.Models;
using NerdOlympics.Data.Repositories;

namespace NerdOlympics.API.FactoryPattern
{
    public static class CompetitionFactory
    {
        public static ICompetition GetCompetition(CompetitionType competitionType)
        {
            switch (competitionType)
            {
                case Data.Enum.Competitions.CompetitionType.Time:
                    return new TimedCompetition();
                // add cases for other types of competition
                default:
                    throw new ArgumentException("Invalid competition type.");
            }
        }
    }
}
