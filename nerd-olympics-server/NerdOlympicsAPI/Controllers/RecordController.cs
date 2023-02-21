using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NerdOlympics.API.Interfaces;
using NerdOlympics.Data.Enum.Security;
using NerdOlympics.Data.Models;
using NerdOlympics.Data.Models.ErrorHandling;

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
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        //[Authorize(Policies.Authenticated)]
        public async Task<IActionResult> GetUserRecords(int userId) 
        { 
            return await _recordService.GetUserRecords(userId);
        }

        [HttpGet]
        [Route("competition")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        //[Authorize(Policies.Authenticated)]
        public async Task<IActionResult> GetCompetitionRecords(int competitionId)
        {
            return await _recordService.GetCompetitionRecords(competitionId);
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        [Authorize(Policies.Authenticated)]
        public async Task<IActionResult> CreateRecord([FromBody] Record record)
        {
            return await _recordService.CreateUserRecord(record);
        }

        [HttpPut]
        [Route("")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        [Authorize(Policies.Authenticated)]
        public async Task<IActionResult> UpdateRecord([FromBody] Record record)
        {
            return await _recordService.UpdateUserRecord(record);
        }

        [HttpDelete]
        [Route("")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        [Authorize(Policies.Authenticated)]
        public async Task<IActionResult> DeleteRecord(int recordId)
        {
            return await _recordService.DeleteUserRecord(recordId);
        }
    }
}
