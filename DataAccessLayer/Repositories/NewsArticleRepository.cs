using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<NewsArticle?> GetById(int id)
        {
            return await _context.NewsArticles
                .Include(na => na.NewsTags)
                .ThenInclude(nt => nt.Tag)
                .FirstOrDefaultAsync(na => na.NewsArticleID == id);
        }

        public async Task<IEnumerable<NewsArticle>> GetAll()
        {
            return await _context.NewsArticles
                .Include(na => na.NewsTags)
                .ThenInclude(nt => nt.Tag)
                .ToListAsync();
        }

        public async Task<NewsArticle> SaveNewsArticle(NewsArticle newsArticle)
        {
            _context.NewsArticles.Add(newsArticle);
            await _context.SaveChangesAsync();
            return newsArticle;
        }

        public async Task<bool> Update(int id, NewsArticle newsArticle)
        {
            var existingNewsArticle = await _context.NewsArticles.FindAsync(id);
            if (existingNewsArticle == null)
            {
                return false;
            }

            existingNewsArticle.NewsTitle = newsArticle.NewsTitle;
            existingNewsArticle.Headline = newsArticle.Headline;
            existingNewsArticle.NewsContent = newsArticle.NewsContent;
            existingNewsArticle.NewsSource = newsArticle.NewsSource;
            existingNewsArticle.NewsStatus = newsArticle.NewsStatus;
            existingNewsArticle.ModifiedDate = newsArticle.ModifiedDate;
            existingNewsArticle.CategoryID = newsArticle.CategoryID;
            existingNewsArticle.CreatedByID = newsArticle.CreatedByID;
            existingNewsArticle.UpdatedByID = newsArticle.UpdatedByID;

            _context.NewsArticles.Update(existingNewsArticle);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var existingNewsArticle = await _context.NewsArticles.FindAsync(id);
            if (existingNewsArticle == null)
            {
                return false;
            }

            _context.NewsArticles.Remove(existingNewsArticle);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
