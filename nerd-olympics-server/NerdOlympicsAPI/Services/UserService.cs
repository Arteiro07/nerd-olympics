using Microsoft.AspNetCore.Mvc;
using NerdOlympics.Data.Cryptography;
using NerdOlympics.Data.Interfaces;
using NerdOlympics.Data.Models;
using NerdOlympicsAPI.Interfaces;

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
                return new UnauthorizedObjectResult(null);

            User? user =  await _userRepository.Authenticate(creds.Email, creds.Password);

            if (user == null)
                return  new UnauthorizedObjectResult(null);

            // Create a JWT that contains the user's claims and a signing key
            string token = _jwtTokenService.GenerateToken(user.UserId!, user.IsAdmin);

            // Return the JWT to the client
            return new OkObjectResult(new { token, user });
        }

        public async Task<IActionResult> CreateUser(SignUpCredentials user)
        {
            if (await _userRepository.CheckEmailExists(user.Email!))
                return new ConflictObjectResult("Email address already in use.");

            var newUser = new User() {
                Name = user.Name,
                Email = user.Email,
                AvatarId = user.AvatarId,  
                Password = PasswordHasher.HashPassword(user.Password!),
                IsAdmin = false,
            };

            var createdUser = await _userRepository.CreateUser(newUser);

            if(createdUser != null)
            {
                // Create a JWT that contains the user's claims and a signing key
                string token = _jwtTokenService.GenerateToken(createdUser.UserId, createdUser.IsAdmin);

                return new OkObjectResult(new { token, createdUser });
            }
            throw new Exception("Error creating user");

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
