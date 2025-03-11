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

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<NewsTag>> GetAll()
        {
            return await _context.NewsTags
            .Include(nt => nt.NewsArticle)
            .Include(nt => nt.Tag)
            .ToListAsync();
        }

        public async Task<NewsTag> GetById(int newsArticleId)
        {
            return await _context.NewsTags.Include(nt => nt.NewsArticle)
                                            .Include(nt => nt.Tag)
                                            .FirstOrDefaultAsync(c => c.NewsArticleID == newsArticleId);
        }

        public async Task<NewsTag> Save(NewsTag newsTag)
        {
            _context.NewsTags.Add(newsTag);
            await _context.SaveChangesAsync();
            return newsTag;
        }

        public async Task Update(NewsTag newsTag)
        {
            _context.Entry(newsTag).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
