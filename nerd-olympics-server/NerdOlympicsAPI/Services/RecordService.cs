using Microsoft.AspNetCore.Mvc;
using NerdOlympics.API.Factory;
using NerdOlympics.API.FactoryPattern;
using NerdOlympics.API.Interfaces;
using NerdOlympics.Data.Interfaces;
using NerdOlympics.Data.Models;
using NerdOlympics.Data.Models.ErrorHandling;
using System.Net;

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
                throw new CustomException((int)HttpStatusCode.NotFound, ErrorMessage.RECORD_NOT_FOUND);

            if (!await _userRepository.UserExists(record.UserId))
                throw new CustomException((int)HttpStatusCode.NotFound, ErrorMessage.USER_NOT_FOUND);

            if (!await _competitionRepository.CompetitionExists(record.CompetitionId))
                throw new CustomException((int)HttpStatusCode.NotFound, ErrorMessage.COMPETITION_NOT_FOUND);

            Record createdRecord = await _recordRepository.CreateUserRecord(record);

            return new OkObjectResult(createdRecord);
        }
        public async Task<IActionResult> UpdateUserRecord(Record record)
        {
            if (record == null || !await _recordRepository.Exists(record.RecordId))
                throw new CustomException((int)HttpStatusCode.NotFound, ErrorMessage.RECORD_NOT_FOUND);

            Record updatedRecord = await _recordRepository.UpdateUserRecord(record);

            return new OkObjectResult(updatedRecord);
        }

        public async Task<IActionResult> DeleteUserRecord(int recordId)
        {
            if (!await _recordRepository.Exists(recordId))
                throw new CustomException((int)HttpStatusCode.NotFound, ErrorMessage.RECORD_NOT_FOUND);

            await _recordRepository.DeleteUserRecord(recordId);
                        
            return new OkResult();
        }

        public async Task<IActionResult> GetCompetitionRecords(int competitionId)
        {
            if (!await _competitionRepository.CompetitionExists(competitionId))
                throw new CustomException((int)HttpStatusCode.NotFound, ErrorMessage.COMPETITION_NOT_FOUND);

            return new OkObjectResult(await _recordRepository.GetCompetitionRecords(competitionId));
        }

        public async Task<IActionResult> GetUserRecords(int userId)
        {
            if (!await _userRepository.UserExists(userId))
                throw new CustomException((int)HttpStatusCode.NotFound, ErrorMessage.USER_NOT_FOUND);

            return new OkObjectResult(await _recordRepository.GetUserRecords(userId));

        }

    }
}
