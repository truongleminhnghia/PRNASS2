using BusinessLayer.Models.Responses;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace UI.Pages.NewsArticle
{
    public class NewsArticleDetailModel : PageModel
    {
        private readonly INewsArticleService _newsArticleService;

        public NewsArticleDetailModel(INewsArticleService newsArticleService)
        {
            _newsArticleService = newsArticleService;
        }

        public NewsArticleResponse Article { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Article = await _newsArticleService.GetById(id);
            if (Article == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}