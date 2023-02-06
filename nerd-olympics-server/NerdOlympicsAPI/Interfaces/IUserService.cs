using Data.Models;
using Microsoft.AspNetCore.Mvc;
using NerdOlympicsData.Models;

namespace NerdOlympicsAPI.Interfaces
{
    public interface IUserService
    {
        Task<User?> Authenticate(string emailAddress, string password);
        Task<IActionResult> CreateUser(LoginCredentials user);
        Task<IActionResult> GetUser(string email);
        Task<IActionResult> GetUsers();
    }
}
