using BlogApp.Models;
using BlogApp.Services.Interfaces;
using BlogTaskApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }

        public async Task<bool> RegisterAsync(User user)
        {
            if (await _context.Users.AnyAsync(u => u.Username == user.Username))
                return false;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
