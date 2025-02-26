using TaskMangmentSystem.Data;
using TaskMangmentSystem.Models;

namespace TaskMangmentSystem.Repositories;
public class UserRepository : IUserRepository{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context) => _context = context;

    public User GetByEmail(string email) => _context.Users.FirstOrDefault(u => u.Email == email);
    public void Add(User user){
        _context.Users.Add(user);
        _context.SaveChanges();
    }
}