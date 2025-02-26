using TaskMangmentSystem.Models;

namespace TaskMangmentSystem.Repositories;
public interface IUserRepository{
    User GetByEmail(string email);
    void Add(User user);
}