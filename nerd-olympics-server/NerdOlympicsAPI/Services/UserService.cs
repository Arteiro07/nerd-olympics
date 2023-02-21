using Microsoft.AspNetCore.Mvc;
using NerdOlympics.Data.Cryptography;
using NerdOlympics.Data.Interfaces;
using NerdOlympics.Data.Models;
using NerdOlympics.Data.Models.ErrorHandling;
using NerdOlympicsAPI.Interfaces;
using System.Net;

namespace NerdOlympicsAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtTokenService;

        public UserService(IUserRepository userRepository, IJwtTokenService jwtTokenService) 
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<IActionResult> Authenticate(LoginCredentials creds)
        {
            if (creds == null || string.IsNullOrEmpty(creds.Email) || string.IsNullOrEmpty(creds.Password))
                throw new CustomException((int)HttpStatusCode.Unauthorized, ErrorMessage.USER_INVALID_CREDENTIALS);

            User user =  await _userRepository.Authenticate(creds.Email, creds.Password);

            // Create a JWT that contains the user's claims and a signing key
            string token = _jwtTokenService.GenerateToken(user.UserId!, user.IsAdmin);

            // Return the JWT to the client
            return new OkObjectResult(new { token, user });
        }

        public async Task<IActionResult> CreateUser(SignUpCredentials user)
        {
            if (await _userRepository.CheckEmailExists(user.Email!))
                throw new CustomException((int)HttpStatusCode.Conflict, ErrorMessage.USER_EMAIL_EXISTS);

            var newUser = new User() {
                Name = user.Name,
                Email = user.Email,
                AvatarId = user.AvatarId,  
                Password = PasswordHasher.HashPassword(user.Password!),
                IsAdmin = false,
            };

            var createdUser = await _userRepository.CreateUser(newUser);

            // Create a JWT that contains the user's claims and a signing key
            string token = _jwtTokenService.GenerateToken(createdUser.UserId, createdUser.IsAdmin);

            return new OkObjectResult(new { token, createdUser });       
        }

        public async Task<IActionResult> GetUsers()
        {
            return new OkObjectResult(await _userRepository.GetUsers());
        }

        public async Task<IActionResult> GetUser(string email)
        {
            return new OkObjectResult(await _userRepository.GetUser(email));
        }
    }
}
