using BusinessLayer.Models.Responses;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface INewsArticleService
    {
        public Task<NewsCountResponse> GetNewsCountsAsync();
        public Task<IEnumerable<NewsArticle>> SearchNewsArticlesAsync(string keyword);
    }
}
