using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MyApp
{
    public class User
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
    }

    public class UserDto
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }
    }

    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly List<User> _users;

        public UserController()
        {
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

            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age
            };
            return Ok(userDto);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers(); // Add controllers to DI container

            var app = builder.Build();

            // Configure the HTTP request pipeline
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
