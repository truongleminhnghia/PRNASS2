using BusinessLayer.Models.Responses;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace UI.Pages.Admins.NewsArticles
{
    public class DetailModel : PageModel
    {
        private readonly INewsArticleService _newsArticleService;

        public DetailModel(INewsArticleService newsArticleService)
        {
            _newsArticleService = newsArticleService;
        }

        public NewsArticleResponse NewsArticle { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            NewsArticle = await _newsArticleService.GetById(id);
            if (NewsArticle == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}