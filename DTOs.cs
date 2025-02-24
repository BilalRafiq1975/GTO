using Microsoft.AspNetCore.Mvc;

namespace MyApp
{
    // Full User class (what we store)
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Password { get; set; } // Private stuff
    }

    // DTO (what we send)
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    // API Controller
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        // Fake user data
        private readonly List<User> _users = new List<User>
        {
            new User { Id = 1, Name = "Bob", Age = 30, Password = "secret" }
        };

        [HttpGet("{id}")]
        public ActionResult GetUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();

            // Move data to DTO
            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age
            };

            return Ok(userDto); // Send DTO, not the full User
        }
    }
}
