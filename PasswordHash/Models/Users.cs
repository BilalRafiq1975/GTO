// Models/User.cs
using System.ComponentModel.DataAnnotations;

namespace SecureAuthApp.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        
        [Required]
        [MaxLength(60)]
        public string PasswordHash { get; set; }
    }
}
