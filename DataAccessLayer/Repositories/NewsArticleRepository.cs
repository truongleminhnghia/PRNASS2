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

        public async Task<List<NewsArticle>> GetAllAsync()
        {
            try
            {
                return await _context.NewsArticles
                    .Where(a => a.NewsStatus == "true")
                    .Include(a => a.Category)
                    .Include(a => a.CreatedBy)
                    .Include(a => a.UpdatedBy)
                    .Include(a => a.NewsTags)
                        .ThenInclude(nt => nt.Tag)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách bài viết: {ex.Message}");
                return new List<NewsArticle>();
            }
        }

        public async Task<NewsArticle?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.NewsArticles
                    .Where(a => a.NewsStatus == "true")
                    .Include(a => a.Category)
                    .Include(a => a.CreatedBy)
                    .Include(a => a.UpdatedBy)
                    .Include(a => a.NewsTags)
                        .ThenInclude(nt => nt.Tag)
                    .FirstOrDefaultAsync(a => a.NewsArticleID == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy bài viết theo ID {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<NewsArticle?> CreateAsync(NewsArticle article, List<int> tagIds)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tạo bài viết: {ex.Message}");
                return null;
            }
        }

        public async Task<NewsArticle?> UpdateAsync(int id, NewsArticle article, List<int> tagIds)
        {
            try
            {
                var existingArticle = await _context.NewsArticles
                    .Include(a => a.NewsTags)
                    .FirstOrDefaultAsync(a => a.NewsArticleID == id);

                if (existingArticle == null)
                {
                    Console.WriteLine($"Bài viết với ID {id} không tồn tại.");
                    return null;
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
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật bài viết {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var article = await _context.NewsArticles.FindAsync(id);
                if (article == null) return false;

                article.NewsStatus = "false"; 
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa bài viết {id}: {ex.Message}");
                return false;
            }
        }

        public async Task<List<NewsArticle>> GetNewsHistoryAsync(int staffId)
        {
            try
            {
                return await _context.NewsArticles
                    .Where(a => a.CreatedByID == staffId) 
                    .OrderByDescending(a => a.CreatedDate) 
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy lịch sử bài viết của nhân viên {staffId}: {ex.Message}");
                return new List<NewsArticle>();
            }
        }
    }
}
