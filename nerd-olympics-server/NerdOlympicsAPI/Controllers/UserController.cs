using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NerdOlympics.Data.Enum;
using NerdOlympics.Data.Models;
using NerdOlympicsAPI.Interfaces;

namespace NerdOlympics.Controllers;

[ApiController]
[Route("users")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
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
    public async Task<IActionResult> CreateUser([FromBody] SignUpCredentials user)
    {
        return await _userService.CreateUser(user);         
    }

    [HttpPost]
    [Route("authentication")]
    public async Task<IActionResult> Authenticate([FromBody] LoginCredentials user)
    {
        return await _userService.Authenticate(user);
    }
}
