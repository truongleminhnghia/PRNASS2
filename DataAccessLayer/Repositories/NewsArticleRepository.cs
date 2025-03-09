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

        public async Task<List<NewsArticle>> GetAllAsync(int? categoryId, List<int>? tagIds)
        {
            var query = _context.NewsArticles
                .Include(a => a.Category)
                .Include(a => a.CreatedBy)
                .Include(a => a.UpdatedBy)
                .Include(a => a.NewsTags)
                    .ThenInclude(nt => nt.Tag)
                .AsQueryable();

            if (categoryId.HasValue)
            {
                query = query.Where(a => a.CategoryID == categoryId);
            }

            if (tagIds != null && tagIds.Any())
            {
                query = query.Where(a => a.NewsTags.Any(nt => tagIds.Contains(nt.TagID)));
            }

            return await query.ToListAsync();
        }

        public async Task<NewsArticle?> GetByIdAsync(int id)
        {
            return await _context.NewsArticles
                .Include(a => a.Category)
                .Include(a => a.CreatedBy)
                .Include(a => a.UpdatedBy)
                .Include(a => a.NewsTags)
                    .ThenInclude(nt => nt.Tag)
                .FirstOrDefaultAsync(a => a.NewsArticleID == id);
        }

        public async Task<NewsArticle> CreateAsync(NewsArticle article, List<int> tagIds)
        {
            _context.NewsArticles.Add(article);
            await _context.SaveChangesAsync();

            if (tagIds.Any())
            {
                var newsTags = tagIds.Select(tagId => new NewsTag
                {
                    NewsArticleID = article.NewsArticleID,
                    TagID = tagId
                }).ToList();

                _context.NewsTags.AddRange(newsTags);
                await _context.SaveChangesAsync();
            }

            return article;
        }

        public async Task<NewsArticle> UpdateAsync(int id, NewsArticle article, List<int> tagIds)
        {
            var existingArticle = await _context.NewsArticles
                .Include(a => a.NewsTags)
                .FirstOrDefaultAsync(a => a.NewsArticleID == id);

            if (existingArticle == null)
            {
                throw new KeyNotFoundException("News article not found.");
            }

            existingArticle.NewsTitle = article.NewsTitle;
            existingArticle.Headline = article.Headline;
            existingArticle.NewsContent = article.NewsContent;
            existingArticle.NewsSource = article.NewsSource;
            existingArticle.NewsStatus = article.NewsStatus;
            existingArticle.ModifiedDate = DateTime.UtcNow;
            existingArticle.CategoryID = article.CategoryID;
            existingArticle.UpdatedByID = article.UpdatedByID;

            // Cập nhật danh sách tag
            var existingTagIds = existingArticle.NewsTags.Select(nt => nt.TagID).ToList();
            var tagsToAdd = tagIds.Except(existingTagIds).ToList();
            var tagsToRemove = existingTagIds.Except(tagIds).ToList();

            if (tagsToAdd.Any())
            {
                var newTags = tagsToAdd.Select(tagId => new NewsTag
                {
                    NewsArticleID = id,
                    TagID = tagId
                }).ToList();
                _context.NewsTags.AddRange(newTags);
            }

            if (tagsToRemove.Any())
            {
                var tagsToDelete = _context.NewsTags
                    .Where(nt => nt.NewsArticleID == id && tagsToRemove.Contains(nt.TagID));
                _context.NewsTags.RemoveRange(tagsToDelete);
            }

            await _context.SaveChangesAsync();
            return existingArticle;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var article = await _context.NewsArticles.FindAsync(id);
            if (article == null) return false;

            _context.NewsArticles.Remove(article);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
