using AutoMapper;
using BusinessLayer.Models.Responses;
using DataAccessLayer.Repositories;
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
        private readonly IMapper _mapper;

        public NewsArticleService(INewsArticleRepository newsArticleRepository, IMapper mapper)
        {
            _newsArticleRepository = newsArticleRepository;
            _mapper = mapper;
        }
        public async Task<NewsCountResponse> GetNewsCountsAsync()
        {
            var (today, thisMonth, thisYear) = await _newsArticleRepository.GetNewsCountsAsync();

            return new NewsCountResponse
            {
                NewsCountToday = today,
                NewsCountThisMonth = thisMonth,
                NewsCountThisYear = thisYear
            };
        }
    }
}
