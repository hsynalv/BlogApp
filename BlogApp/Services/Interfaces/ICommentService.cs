using BlogApp.Models;

namespace BlogApp.Services.Interfaces
{
    public interface ICommentService
    {
        Task<List<Comment>> GetByPostIdAsync(int postId);
        Task AddCommentAsync(Comment comment);
    }
}
