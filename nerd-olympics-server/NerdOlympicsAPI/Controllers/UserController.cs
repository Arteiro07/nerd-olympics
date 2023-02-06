using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using NerdOlympicsAPI.Interfaces;
using NerdOlympicsData.Enum;
using NerdOlympicsData.Models;
using System.Security.Cryptography;

namespace NerdOlympics.Controllers;

[ApiController]
[Route("users")]
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;
    private readonly IJwtTokenService _jwtTokenService;

    public UserController(ILogger<UserController> logger, IUserService userService, IJwtTokenService jwtTokenService)
    {
        _logger = logger;
        _userService = userService;
        _jwtTokenService = jwtTokenService;
    }

    [HttpGet]
    [Route("all")]
    [Authorize(Policies.Authenticated)]
    [Authorize(Policies.Admin)]
    public async Task<IActionResult> GetUsers()
    {
        return await _userService.GetUsers();
    }

    [HttpGet]
    [Route("")]
    [Authorize(Policies.Authenticated)]
    public async Task<IActionResult> GetUserbyEmail(string email)
    {
         return await _userService.GetUser(email);
    }


    [HttpPost]
    [Route("registration")]
    public async Task<IActionResult> RegisterUser([FromBody] LoginCredentials user)
    {
        return await _userService.CreateUser(user);         
    }

    [HttpPost]
    [Route("authentication")]
    public async Task<IActionResult> Authenticate([FromBody] LoginCredentials login)
    {
        if(string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Password))
            return Unauthorized();

        User? user = await _userService.Authenticate(login.Email!, login.Password!);

        if (user == null)        
            return Unauthorized();        

        // Create a JWT that contains the user's claims and a signing key
        string token = _jwtTokenService.GenerateToken(user.EmailAddress!, user.IsAdmin);

        // Return the JWT to the client
        return Ok(new { token, user });
    }
}
