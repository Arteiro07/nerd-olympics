using Data.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using NerdOlympicsAPI.Interfaces;
using NerdOlympicsData.Cryptography;
using NerdOlympicsData.Models;

namespace NerdOlympicsAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Authenticate(string emailAddress, string password)
        {
            return await _userRepository.Authenticate(emailAddress, password);
        }

        public async Task<IActionResult> CreateUser(LoginCredentials user)
        {
            var newUser = new User() {
                Name = user.Name,
                EmailAddress = user.Email,
                Password = PasswordHasher.HashPassword(user.Password!),
                IsAdmin = false,
            };

            var createdUser = await _userRepository.CreateUser(newUser);

            if(createdUser != null)
            {
                return new OkObjectResult(createdUser);
            }
            return new ConflictObjectResult("Email already in use");
        }

        public async Task<IActionResult> GetUsers()
        {
            return new OkObjectResult(await _userRepository.GetUsers());
        }

        public async Task<IActionResult> GetUser(string email)
        {
            var user = await _userRepository.GetUsers(email);

            if(user == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(user);
        }
    }
}
