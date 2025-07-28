using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class Category
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori adı gereklidir")]
        [StringLength(100)]
        public string Name { get; set; }

         public ICollection<Post>? Posts { get; set; }

    }
}
