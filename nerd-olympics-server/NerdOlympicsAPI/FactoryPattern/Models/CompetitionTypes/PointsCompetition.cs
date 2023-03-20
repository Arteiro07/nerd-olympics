using NerdOlympics.API.Factory;
using NerdOlympics.Data.Enum.Competitions;
using NerdOlympics.Data.Interfaces;
using NerdOlympics.Data.Models;
using NerdOlympics.Data.Models.ErrorHandling;
using NerdOlympics.Data.Repositories;
using System.Net;

namespace NerdOlympics.API.FactoryPattern.Models.CompetitionTypes
{
    public class PointsCompetition : ICompetition
    {
        public ClassificationType ClassificationType { get; }
        public IFactoryRepository _repository { get; }

        public int CompetitionID { get; }

        public PointsCompetition(IFactoryRepository repository, int competitionId, ClassificationType classificationType) 
        {
            _repository = repository;
            CompetitionID = competitionId;
            ClassificationType = classificationType;
        }

        public async Task<List<ScoreLine>> Leaderboard() 
        {
            // get the records from DB with users attached
            // cast them to score line elems 

            var records = (await _repository.GetCompetitionRecordsWithUsers(CompetitionID)).Select(x => new ScoreLine
            {
                CompetitionId = x.CompetitionId,
                Description = x.Description,
                RecordId = x.RecordId,
                UserGender = x.User.Gender,
                UserId = x.UserId,
                UserName = x.User.Name ?? "",
                Value = int.Parse(x.Value),
                OverallPoints = 0,
                Position = -1
            }).ToList();

            return await OrderRecords(records);
        }
        public async Task<List<ScoreLine>> UserLeaderboard(int userId)
        {
            var records = (await _repository.GetCompetitionUserRecords(CompetitionID, userId)).Select(x => new ScoreLine
            {
                CompetitionId = x.CompetitionId,
                Description = x.Description,
                RecordId = x.RecordId,
                UserGender = x.User.Gender,
                UserId = x.UserId,
                UserName = x.User.Name ?? "",
                Value = float.Parse(x.Value),
                OverallPoints = 0,
                Position = -1
            }).ToList();

            return await OrderUserRecords(records);
        }

        private async Task<List<ScoreLine>> OrderRecords(List<ScoreLine> records)
        {
            if (!records.Any())
                return new List<ScoreLine>();

            //select best record by user
            // order them accordingly 
            if (ClassificationType == ClassificationType.Ascendant)
            {
                records = records
                    .GroupBy(x => x.UserId)
                    .Select(x => x.OrderByDescending(y => y.Value).FirstOrDefault()).ToList();
            }
            else if (ClassificationType == ClassificationType.Descendant)
            {
                records = records
                    .GroupBy(x => x.UserId)
                    .Select(x => x.OrderBy(y => y.Value).FirstOrDefault()).ToList();
            }
            else
                throw new CustomException((int)HttpStatusCode.BadRequest, ErrorMessage.COMPETITION_ClASSIFICATION_TYPE_NOT_FOUND);

            var entries = records.Count();
            var position = 1;
            foreach (var record in records)
            {
                record.Position = position;
                record.OverallPoints = entries - position;
                position++;
            }

            return records.ToList();
        }

        private async Task<List<ScoreLine>> OrderUserRecords(List<ScoreLine> records)
        {
            if (!records.Any())
                return new List<ScoreLine>();

            //select best record by user
            // order them accordingly 
            if (ClassificationType == ClassificationType.Ascendant)
            {
                records = records.OrderByDescending(y => y.Value).ToList();
            }
            else if (ClassificationType == ClassificationType.Descendant)
            {
                records = records.OrderBy(y => y.Value).ToList();
            }
            else
                throw new CustomException((int)HttpStatusCode.BadRequest, ErrorMessage.COMPETITION_ClASSIFICATION_TYPE_NOT_FOUND);

            var entries = records.Count();
            var position = 1;
            foreach (var record in records)
            {
                record.Position = position;
                //record.OverallPoints = entries - position;
                position++;
            }

            return records.ToList();
        }
    }
}
