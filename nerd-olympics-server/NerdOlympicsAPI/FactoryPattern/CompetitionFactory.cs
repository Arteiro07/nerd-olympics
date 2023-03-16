﻿using NerdOlympics.API.Factory;
using NerdOlympics.API.FactoryPattern.Models.CompetitionTypes;
using NerdOlympics.API.Interfaces;
using NerdOlympics.Data.Enum.Competitions;
using NerdOlympics.Data.Interfaces;
using NerdOlympics.Data.Models;
using NerdOlympics.Data.Models.ErrorHandling;
using NerdOlympics.Data.Repositories;
using System.Net;

namespace NerdOlympics.API.FactoryPattern
{
    public class CompetitionFactory
    {
        private readonly IFactoryRepository _context;

        public CompetitionFactory(IFactoryRepository context)
        {
            _context = context;
        }

        public ICompetition GetCompetition(CompetitionType competitionType, ClassificationType classificationType, int competitionId)
        {
            switch (competitionType)
            {
                case CompetitionType.Time:
                    return new TimedCompetition(_context, competitionId, classificationType);
                // add cases for other types of competition
                default:
                    throw new CustomException((int)HttpStatusCode.NotFound,ErrorMessage.COMPETITION_TYPE_NOT_FOUND);
            }
        }
    }
}
