using BlogApp.Models;

namespace BlogApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<User?> AuthenticateAsync(string username, string password);
        Task<bool> RegisterAsync(User user);
        Task<List<User>> GetAllAsync();
    }
}
