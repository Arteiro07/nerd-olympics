using Microsoft.AspNetCore.Mvc;
using NerdOlympics.Data.Models;

namespace NerdOlympicsAPI.Interfaces
{
    public interface IUserService
    {
        Task<IActionResult> Authenticate(LoginCredentials user);
        Task<IActionResult> CreateUser(SignUpCredentials user);
        Task<IActionResult> EmailInUse(string email);
        Task<IActionResult> GetUser(string email);
        Task<IActionResult> GetUsers();
    }
}
