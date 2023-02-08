using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NerdOlympics.API.Interfaces;
using NerdOlympics.Data.Enum;
using NerdOlympics.Data.Models;

namespace NerdOlympics.API.Controllers
{
    [ApiController]
    [Route("records")]
    public class RecordController : Controller
    {
        IRecordService _recordService;
        public RecordController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        [HttpGet]
        [Route("user")]
        [Authorize(Policies.Authenticated)]
        public async Task<IActionResult> GetUserRecords(int userId) 
        { 
            return await _recordService.GetUserRecords(userId);
        }

        [HttpGet]
        [Route("competition")]
        [Authorize(Policies.Authenticated)]
        public async Task<IActionResult> GetCompetitionRecords(int competitionId)
        {
            return await _recordService.GetCompetitionRecords(competitionId);
        }

        [HttpPost]
        [Route("")]
        [Authorize(Policies.Authenticated)]
        public async Task<IActionResult> CreateRecord([FromBody] Record record)
        {
            return await _recordService.CreateUserRecord(record);
        }

        [HttpPut]
        [Route("")]
        [Authorize(Policies.Authenticated)]
        public async Task<IActionResult> UpdateRecord([FromBody] Record record)
        {
            return await _recordService.UpdateUserRecord(record);
        }

        [HttpDelete]
        [Route("")]
        [Authorize(Policies.Authenticated)]
        public async Task<IActionResult> DeleteRecord(int recordId)
        {
            return await _recordService.DeleteUserRecord(recordId);
        }
    }
}
