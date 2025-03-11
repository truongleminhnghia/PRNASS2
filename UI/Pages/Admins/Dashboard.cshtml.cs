using BusinessLayer.Models.Responses;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace UI.Pages.Admins
{
    public class DashboardModel : PageModel
    {
        private readonly INewsArticleService _newsArticleService;

        public DashboardModel(INewsArticleService newsArticleService)
        {
            _newsArticleService = newsArticleService;
        }

        [BindProperty(SupportsGet = true)]
        public string ReportType { get; set; } = "day";

        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; } = DateTime.UtcNow.AddMonths(-1);

        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; } = DateTime.UtcNow;

        public DashboardStatistics Statistics { get; set; }

        public async Task OnGetAsync()
        {
            Statistics = await _newsArticleService.GetDashboardStatistics(ReportType, StartDate, EndDate);
        }

        public async Task<IActionResult> OnGetStatisticsAsync(string reportType, DateTime startDate, DateTime endDate)
        {
            var statistics = await _newsArticleService.GetDashboardStatistics(reportType, startDate, endDate);
            return new JsonResult(new
            {
                activeArticlesCount = statistics.ActiveArticlesCount,
                inactiveArticlesCount = statistics.InactiveArticlesCount,
                articlesPublishedPerPeriod = statistics.ArticlesPublishedPerPeriod,
                totalArticlesPerPeriod = statistics.TotalArticlesPerPeriod
            });
        }
    }
}
