using BusinessLayer.Models.Requests;
using BusinessLayer.Models.Responses;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UI.Pages.Admins.NewsArticles
{
    public class IndexModel : PageModel
    {
        private readonly INewsArticleService _newsArticleService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;

        public IndexModel(INewsArticleService newsArticleService, ICategoryService categoryService, ITagService tagService)
        {
            _newsArticleService = newsArticleService;
            _categoryService = categoryService;
            _tagService = tagService;
        }

        public IEnumerable<NewsArticleResponse> NewsArticles { get; set; }
        public IEnumerable<CategoryResponse> Categories { get; set; }
        public IEnumerable<TagResponse> Tags { get; set; }

        [BindProperty]
        public NewsArticleRequest NewsArticle { get; set; }

        public async Task OnGetAsync()
        {
            NewsArticles = await _newsArticleService.GetAll();
            Categories = await _categoryService.GetAll();
            Tags = await _tagService.GetAll();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                NewsArticles = await _newsArticleService.GetAll();
                Categories = await _categoryService.GetAll();
                Tags = await _tagService.GetAll();
                return Page();
            }

            try
            {
                await _newsArticleService.SaveNewsArticle(NewsArticle);
                TempData["Message"] = "News article created successfully.";
            }
            catch
            {
                TempData["Message"] = "Failed to create news article. Please try again.";
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            try
            {
                await _newsArticleService.Delete(id);
                TempData["Message"] = "News article deleted successfully.";
            }
            catch
            {
                TempData["Message"] = "Failed to delete news article. Please try again.";
            }

            return RedirectToPage();
        }
    }
}