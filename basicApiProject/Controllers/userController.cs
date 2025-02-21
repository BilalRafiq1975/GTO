using Microsoft.AspNetCore.Mvc;
using basicApiProject.Models;


namespace basicApiProject.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> users = new()
        {
            new User { Id = 1, Name = "Bilal", Email = "bilal.q@dplit.com" }
        };

        [HttpGet]
        public ActionResult<List<User>> GetUsers() => Ok(users);

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id) =>
            users.FirstOrDefault(u => u.Id == id) is User user ? Ok(user) : NotFound();

        [HttpPost]
        public ActionResult<User> AddUser(User user)
        {
            users.Add(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, User updatedUser)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();

            users.Remove(user);
            return NoContent();
        }
    }
}
