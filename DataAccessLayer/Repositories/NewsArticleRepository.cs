using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class NewsArticleRepository : INewsArticleRepository
    {
        private readonly ApplicationDbContext _context;

        public NewsArticleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(int Today, int ThisMonth, int ThisYear)> GetNewsCountsAsync()
        {
            var now = DateTime.UtcNow; // Use UTC to avoid timezone issues

            var newsCountToday = await _context.NewsArticles
                .CountAsync(article => article.CreatedDate.Date == now.Date);

            var newsCountThisMonth = await _context.NewsArticles
                .CountAsync(article => article.CreatedDate.Year == now.Year && article.CreatedDate.Month == now.Month);

            var newsCountThisYear = await _context.NewsArticles
                .CountAsync(article => article.CreatedDate.Year == now.Year);

            return (newsCountToday, newsCountThisMonth, newsCountThisYear);
        }
    }
}
