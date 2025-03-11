using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessLayer.Models.Responses;
using BusinessLayer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UI.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly INewsArticleService _newsArticleService;

		public IndexModel(ILogger<IndexModel> logger, INewsArticleService newsArticleService)
		{
			_logger = logger;
			_newsArticleService = newsArticleService;
		}

		public List<NewsArticleResponse> RecentArticles { get; set; }

		public async Task OnGetAsync()
		{
			RecentArticles = await _newsArticleService.GetRecentArticles(10);
		}

		public IActionResult OnPostLogout()
		{
			HttpContext.Session.Clear();
			return RedirectToPage("/Index");
		}
	}
}
