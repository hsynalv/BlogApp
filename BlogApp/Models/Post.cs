using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık gereklidir")]
        [StringLength(200)]
        public string Title { get; set; }

        [Required(ErrorMessage = "İçerik gereklidir")]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public int CategoryId { get; set; }

        [ValidateNever]
        public Category Category { get; set; }
    }
}
