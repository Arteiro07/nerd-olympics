﻿using NerdOlympics.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace NerdOlympicsAPI.Interfaces
{
    public interface ICompetitionsService
    {
        Task<IActionResult> GetCompetitions();
        Task<IActionResult> GetCompetition(int competitionId);
        Task<IActionResult> CreateCompetition(Competition competition);
        Task<IActionResult> UpdateCompetition(Competition competition, string userId);
        Task<IActionResult> CompetitionNameExists(string competitionName);
    }
}
