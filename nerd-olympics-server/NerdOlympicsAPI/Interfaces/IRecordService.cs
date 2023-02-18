using Microsoft.AspNetCore.Mvc;
using NerdOlympics.Data.Models;

namespace NerdOlympics.API.Interfaces
{
    public interface IRecordService
    {
        Task<IActionResult> GetUserRecords(int userId);
        Task<IActionResult> GetCompetitionRecords(int competitionId);
        Task<IActionResult> CreateUserRecord(Record record);
        Task<IActionResult> UpdateUserRecord(Record record);
        Task<IActionResult> DeleteUserRecord(int recordId);
    }
}
