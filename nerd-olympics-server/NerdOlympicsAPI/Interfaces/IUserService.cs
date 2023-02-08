using Data.Models;
using Microsoft.AspNetCore.Mvc;
using NerdOlympicsData.Models;

namespace NerdOlympicsAPI.Interfaces
{
    public interface IUserService
    {
        Task<IActionResult> Authenticate(LoginCredentials user);
        Task<IActionResult> CreateUser(SignUpCredentials user);
        Task<IActionResult> GetUser(string email);
        Task<IActionResult> GetUsers();
    }
}
