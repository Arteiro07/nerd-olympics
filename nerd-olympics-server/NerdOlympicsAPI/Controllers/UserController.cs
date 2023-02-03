using Data.Models;
using Microsoft.AspNetCore.Mvc;
using NerdOlympicsAPI.Interfaces;

namespace NerdOlympics.Controllers;

[ApiController]
[Route("users")]
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet]
    [Route("")]
    public async Task<List<User>> GetUsers()
    {
        return await _userService.GetUsers();
    }
}
