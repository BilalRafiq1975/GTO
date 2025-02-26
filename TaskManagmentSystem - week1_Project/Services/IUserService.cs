using TaskMangmentSystem.DTOs;

namespace TaskManagementSystem.Services;
public interface IUserService
{
    UserDto Register(string username, string email, string password);
    UserDto Login(string email, string password);
}