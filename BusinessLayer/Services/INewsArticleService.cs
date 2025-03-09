using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models.Requests;
using BusinessLayer.Models.Responses;
using DataAccessLayer.Entities;

namespace BusinessLayer.Services
{
    public interface INewsArticleService
    {
        Task<List<NewsArticle>> GetAllAsync(int? categoryId, List<int>? tagIds);
        Task<NewsArticle?> GetByIdAsync(int id);
        Task<NewsArticle> CreateAsync(NewsArticle article, List<int> tagIds);
        Task<NewsArticle> UpdateAsync(int id, NewsArticle article, List<int> tagIds);
        Task<bool> DeleteAsync(int id);
    }
}
