using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using BCrypt.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TaskMangmentSystem.DTOs;
using TaskMangmentSystem.Models;
using TaskMangmentSystem.Repositories;

namespace TaskManagementSystem.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepo, IConfiguration config, IMapper mapper)
    {
        _userRepo = userRepo;
        _config = config;
        _mapper = mapper;
    }

    public UserDto Register(string username, string email, string password)
    {
        if (_userRepo.GetByEmail(email) != null)
            throw new Exception("Email already exists");

        var user = new User
        {
            UserName = username,
            Email = email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
        };
        _userRepo.Add(user);
        return _mapper.Map<UserDto>(user);
    }

    public UserDto Login(string email, string password)
    {
        var user = _userRepo.GetByEmail(email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            throw new Exception("Invalid credentials");

        var token = GenerateJwtToken(user);
        var userDto = _mapper.Map<UserDto>(user);
        userDto.Token = token;
        return userDto;
    }

    private string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}