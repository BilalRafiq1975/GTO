using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Swashbuckle.AspNetCore.SwaggerGen; // For AddSwaggerGen
using Swashbuckle.AspNetCore.SwaggerUI;  // For UseSwagger and UseSwaggerUI

namespace MyApp
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>(); 
        }
    }

    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly List<User> _users;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper)
        {
            _mapper = mapper;
            _users = new List<User>
            {
                new User { Id = 1, Name = "Bilal", Age = 30, Password = "abc" }
            };
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();

            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPost]
        public ActionResult<UserDto> CreateUser([FromBody] UserDto userDto)
        {
            // Generate a new ID (simple increment for this example)
            int newId = _users.Max(u => u.Id) + 1;

            // Map UserDto to User (including a default Password for this example)
            var user = _mapper.Map<User>(userDto);
            user.Id = newId;
            user.Password = "defaultPassword"; // Add a default password or handle it differently in a real app

            // Add the new user to the list
            _users.Add(user);

            // Map back to UserDto for the response (exclude Password)
            var createdUserDto = _mapper.Map<UserDto>(user);

            // Return 201 Created with the new resource
            return StatusCode(201, createdUserDto);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(Program));

            // Add Swagger services for API documentation
            builder.Services.AddEndpointsApiExplorer(); // Provides metadata for Swagger
            builder.Services.AddSwaggerGen(); // Adds Swagger generation

            var app = builder.Build();

            // Configure the HTTP request pipeline
            // Enable Swagger in all environments for now (remove or adjust for production)
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
