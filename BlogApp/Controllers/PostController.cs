using BlogApp.Models;
using BlogApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogTaskApp.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;

        public PostController(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _postService.GetAllAsync();
            return View(posts);
        }

        public async Task<IActionResult> Create()
        {
            await LoadCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Post post)
        {
            if (ModelState.IsValid)
            {
                await _postService.CreateAsync(post);
                return RedirectToAction(nameof(Index));

            }
            await LoadCategories();
            return View(post);

        }


        public async Task<IActionResult> Edit(int id)
        {
            var post = await _postService.GetByIdAsync(id);
            if (post == null) return NotFound();
            await LoadCategories();
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                await _postService.UpdateAsync(post);
                return RedirectToAction(nameof(Index));
            }
            await LoadCategories();
            return View(post);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var post = await _postService.GetByIdAsync(id);
            if (post == null) return NotFound();
            return View(post);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _postService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task LoadCategories()
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
        }
    }
}
