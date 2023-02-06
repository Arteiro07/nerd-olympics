using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace NerdOlympicsAPI.Interfaces
{
    public interface ICompetitionsService
    {
        Task<IActionResult> GetCompetitions();
        Task<IActionResult> CreateCompetition(Competition competition);
    }
}
