using BlogApp.Models;
using BlogApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;

        public HomeController(IPostService postService, ICategoryService categoryService, ICommentService commentService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(int postId, string content, string? authorName)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                ModelState.AddModelError("", "Yorum boþ olamaz.");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Details", new { id = postId });
            }

            var comment = new Comment
            {
                PostId = postId,
                Content = content,
                AuthorName = authorName ?? "Anonim",
                CreatedAt = DateTime.Now
            };

            await _commentService.AddCommentAsync(comment);

            return RedirectToAction("Details", new { id = postId });
        }

        public async Task<IActionResult> Index(int? categoryId, string search)
        {
            var categories = await _categoryService.GetAllAsync();

            var allPosts = await _postService.GetAllAsync();

            var filteredPosts = allPosts.AsQueryable();

            if (categoryId.HasValue)
                filteredPosts = filteredPosts.Where(p => p.CategoryId == categoryId.Value);

            if (!string.IsNullOrEmpty(search))
                filteredPosts = filteredPosts.Where(p => p.Title.Contains(search, StringComparison.OrdinalIgnoreCase));

            var filteredPostsList = filteredPosts.ToList();

            var categoriesWithCount = categories.Select(c => new
            {
                Category = c,
                Count = allPosts.Count(p => p.CategoryId == c.Id)
            }).ToList<dynamic>();

            ViewBag.CategoriesWithCount = categoriesWithCount;
            ViewBag.SelectedCategoryId = categoryId;
            ViewBag.SearchQuery = search;

            return View(filteredPostsList.OrderByDescending(p => p.CreatedAt).ToList());
        }

        public async Task<IActionResult> Details(int id)
        {
            var post = await _postService.GetByIdAsync(id);
            if (post == null) return NotFound();

            var comments = await _commentService.GetByPostIdAsync(id);
            ViewBag.Comments = comments;

            return View(post);
        }

    }
}
