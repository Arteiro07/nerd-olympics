using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NerdOlympics.Data.Enum.Security;
using NerdOlympics.Data.Models;
using NerdOlympics.Data.Models.ErrorHandling;
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
    [ProducesResponseType(typeof(IActionResult), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> GetUsers()
    {
        return await _userService.GetUsers();
    }

    [HttpGet]
    [Route("")]
    [Authorize(Policies.Authenticated)]
    [ProducesResponseType(typeof(IActionResult), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> GetUserbyEmail(string email)
    {
         return await _userService.GetUser(email);
    }

    [HttpPost]
    [Route("registration")]
    [ProducesResponseType(typeof(IActionResult), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> CreateUser([FromBody] SignUpCredentials user)
    {
        return await _userService.CreateUser(user);         
    }

    [HttpPost]
    [Route("authentication")]
    [ProducesResponseType(typeof(IActionResult), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public async Task<IActionResult> Authenticate([FromBody] LoginCredentials user)
    {
        return await _userService.Authenticate(user);
    }
}
