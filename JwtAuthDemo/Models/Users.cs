namespace JwtAuthDemo.Models;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; } // In reality, hash this!
}