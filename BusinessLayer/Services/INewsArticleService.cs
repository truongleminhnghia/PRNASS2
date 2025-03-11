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
        Task<NewsArticleResponse> SaveNewsArticle(NewsArticleRequest newsArticleRequest);
        Task<NewsArticleResponse?> GetById(int id);
        Task<IEnumerable<NewsArticleResponse>> GetAll();
        Task<bool> Update(int id, NewsArticleRequest newsArticleRequest);
        Task<bool> Delete(int id);
    }
}
