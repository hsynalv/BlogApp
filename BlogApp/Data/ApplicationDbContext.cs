using BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogTaskApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Deneme" },
                new Category { Id = 2, Name = "Yazılım" },
                new Category { Id = 3, Name = "Siber Güvenlik" }
            );

            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Title = "İlk Deneme Yazısı",
                    Content = "Deneme kategorisi için ilk yazı.",
                    CreatedAt = new DateTime(2025, 7, 28, 10, 0, 0),  // statik tarih
                    CategoryId = 1
                },
                new Post
                {
                    Id = 2,
                    Title = "Yazılım Dünyasına Giriş",
                    Content = "Yazılım kategorisi için ilk yazı.",
                    CreatedAt = new DateTime(2025, 7, 28, 10, 30, 0),
                    CategoryId = 2
                }
);

            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    PostId = 1,
                    AuthorName = "Anonim",
                    Content = "Güzel bir yazı olmuş.",
                    CreatedAt = new DateTime(2025, 7, 28, 11, 0, 0)
                },
                new Comment
                {
                    Id = 2,
                    PostId = 2,
                    AuthorName = "Ziyaretçi",
                    Content = "Yararlı bilgiler için teşekkürler.",
                    CreatedAt = new DateTime(2025, 7, 28, 11, 15, 0)
                }
);
        }

    }
}
