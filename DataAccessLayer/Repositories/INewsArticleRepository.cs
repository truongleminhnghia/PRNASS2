using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public interface INewsArticleRepository
    {
        Task<List<NewsArticle>> GetAllAsync(int? categoryId, List<int>? tagIds);
        Task<NewsArticle?> GetByIdAsync(int id);
        Task<NewsArticle> CreateAsync(NewsArticle article, List<int> tagIds);
        Task<NewsArticle> UpdateAsync(int id, NewsArticle article, List<int> tagIds);
        Task<bool> DeleteAsync(int id);
    }
}