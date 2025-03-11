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
        Task<NewsArticle> SaveNewsArticle(NewsArticle newsArticle);
        Task<NewsArticle?> GetById(int id);
        Task<IEnumerable<NewsArticle>> GetAll();
        Task<bool> Update(int id, NewsArticle newsArticle);
        Task<bool> Delete(int id);
    }
}