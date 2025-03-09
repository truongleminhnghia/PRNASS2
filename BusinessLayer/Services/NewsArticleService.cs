using AutoMapper;
using BusinessLayer.Models.Requests;
using BusinessLayer.Models.Responses;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BusinessLayer.Services
{
    public class NewsArticleService : INewsArticleService
    {
        private readonly INewsArticleRepository _newsArticleRepository;

        public NewsArticleService(INewsArticleRepository newsArticleRepository)
        {
            _newsArticleRepository = newsArticleRepository;
        }

        public async Task<List<NewsArticle>> GetAllAsync()
        {
            return await _newsArticleRepository.GetAllAsync();
        }

        public async Task<NewsArticle?> GetByIdAsync(int id)
        {
            return await _newsArticleRepository.GetByIdAsync(id);
        }

        public async Task<NewsArticle> CreateAsync(NewsArticle article, List<int> tagIds)
        {
            return await _newsArticleRepository.CreateAsync(article, tagIds);
        }

        public async Task<NewsArticle> UpdateAsync(int id, NewsArticle article, List<int> tagIds)
        {
            return await _newsArticleRepository.UpdateAsync(id, article, tagIds);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _newsArticleRepository.DeleteAsync(id);
        }
        public async Task<List<NewsArticle>> GetNewsHistoryAsync(int staffId)
        {
            return await _newsArticleRepository.GetNewsHistoryAsync(staffId);
        }
    }
}
