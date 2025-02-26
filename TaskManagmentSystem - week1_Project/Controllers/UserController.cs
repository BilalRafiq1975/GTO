using Microsoft.AspNetCore.Mvc;
using TaskMangmentSystem.DTOs;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService) => _userService = userService;

    [HttpPost("signup")]
    public IActionResult Signup([FromBody] SignupRequest request)
    {
        try
        {
            var user = _userService.Register(request.Username, request.Email, request.Password);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        try
        {
            var user = _userService.Login(request.Email, request.Password);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

public class SignupRequest
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}