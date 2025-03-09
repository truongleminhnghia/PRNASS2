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
    public class NewsTagRepository : INewsTagRepository
    {
        private readonly ApplicationDbContext _context;

        public NewsTagRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddTagsToArticleAsync(int articleId, List<int> tagIds)
        {
            var newsTags = tagIds.Select(tagId => new NewsTag
            {
                NewsArticleID = articleId,
                TagID = tagId
            }).ToList();

            await _context.NewsTags.AddRangeAsync(newsTags);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveTagsFromArticleAsync(int articleId)
        {
            var existingTags = await _context.NewsTags.Where(nt => nt.NewsArticleID == articleId).ToListAsync();

            _context.NewsTags.RemoveRange(existingTags);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Tag>> GetTagsByArticleIdAsync(int articleId)
        {
            return await _context.NewsTags.Where(nt => nt.NewsArticleID == articleId).Select(nt => nt.Tag).ToListAsync();
        }
    }
}
