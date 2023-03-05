using Microsoft.AspNetCore.Mvc;
using NerdOlympics.API.Factory;
using NerdOlympics.API.FactoryPattern;
using NerdOlympics.API.Interfaces;
using NerdOlympics.Data.Interfaces;
using NerdOlympics.Data.Models;

namespace NerdOlympics.API.Services
{
    public class RecordService: IRecordService
    {
        IRecordRepository _recordRepository;
        IUserRepository _userRepository;
        ICompetitionRepository _competitionRepository;

        public RecordService(IRecordRepository recordRepository, IUserRepository userRepository, ICompetitionRepository competitionRepository) 
        {
            _recordRepository = recordRepository;
            _userRepository = userRepository;
            _competitionRepository = competitionRepository;
        }

        public async Task<IActionResult> CreateUserRecord(Record record)
        {
            if (record == null)
                throw new Exception("Invalid record");

            if (!await _userRepository.UserExists(record.UserId))
                throw new Exception("User does not exist");

            if (!await _competitionRepository.CompetitionExists(record.CompetitionId))
                throw new Exception("Competition does not exist");

            Record? createdRecord = await _recordRepository.CreateUserRecord(record);

            if (createdRecord == null) throw new Exception("Error creating record");

            return new OkObjectResult(createdRecord);
        }
        public async Task<IActionResult> UpdateUserRecord(Record record)
        {
            if (record == null || !await _recordRepository.Exists(record.RecordId))
                throw new Exception("Invalid record");

            Record? updatedRecord = await _recordRepository.UpdateUserRecord(record);

            if (updatedRecord == null) throw new Exception("Error updating record");

            return new OkObjectResult(updatedRecord);
        }

        public async Task<IActionResult> DeleteUserRecord(int recordId)
        {
            if (!await _recordRepository.Exists(recordId))
                throw new Exception("Invalid record");

            var success = await _recordRepository.DeleteUserRecord(recordId);

            if (!success) throw new Exception("Error deleting record");
            
            return new OkResult();
        }

        public async Task<IActionResult> GetCompetitionRecords(int competitionId)
        {
            if (!await _competitionRepository.CompetitionExists(competitionId))
                throw new Exception("Competition does not exist");

            return new OkObjectResult(await _recordRepository.GetCompetitionRecords(competitionId));
        }

        public async Task<IActionResult> GetUserRecords(int userId)
        {
            if (!await _userRepository.UserExists(userId))
                throw new Exception("User does not exist");

            return new OkObjectResult(await _recordRepository.GetUserRecords(userId));

        }

    }
}
