using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı zorunludur")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur")]
        public string Password { get; set; }

        public string Role { get; set; } = "User"; 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
