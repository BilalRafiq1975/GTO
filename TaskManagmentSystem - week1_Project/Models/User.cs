using System.ComponentModel.DataAnnotations;
namespace TaskMangmentSystem.Models;

public class User{
    public int Id {get; set;}

    [Required(ErrorMessage = "Username is required.")]
    [MinLength(3, ErrorMessage = "Username must be at least 3 characters long.")]
    [MaxLength(50, ErrorMessage = "Username cannot exceed 50 characters.")]
    public string UserName {get; set;}

    [Required(ErrorMessage = "Email is Required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email {get; set;}

    [Required(ErrorMessage = "Password is required.")]
    [MinLength(6, ErrorMessage = "Password must be atleast 6 characters long.")]
    [MaxLength(100, ErrorMessage = "Password cannot exceed 100 characters.")]
    public string PasswordHash {get; set;}
}