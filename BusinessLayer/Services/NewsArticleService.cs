using AutoMapper;
using BusinessLayer.Models.Requests;
using BusinessLayer.Models.Responses;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class NewsArticleService : INewsArticleService
    {
        private readonly INewsArticleRepository _repository;
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public NewsArticleService(INewsArticleRepository repository, ITagRepository tagRepository, IMapper mapper)
        {
            _repository = repository;
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<NewsArticleResponse> SaveNewsArticle(NewsArticleRequest newsArticleRequest)
        {
            var newsArticle = _mapper.Map<NewsArticle>(newsArticleRequest);

            // Add tags to the news article
            if (newsArticleRequest.TagIDs != null && newsArticleRequest.TagIDs.Any())
            {
                newsArticle.NewsTags = new List<NewsTag>();
                foreach (var tagId in newsArticleRequest.TagIDs)
                {
                    var tag = await _tagRepository.GetById(tagId);
                    if (tag != null)
                    {
                        newsArticle.NewsTags.Add(new NewsTag { TagID = tag.TagID, Tag = tag });
                    }
                }
            }

            var savedNewsArticle = await _repository.SaveNewsArticle(newsArticle);
            return _mapper.Map<NewsArticleResponse>(savedNewsArticle);
        }

        public async Task<NewsArticleResponse?> GetById(int id)
        {
            var newsArticle = await _repository.GetById(id);
            return newsArticle == null ? null : _mapper.Map<NewsArticleResponse>(newsArticle);
        }

        public async Task<IEnumerable<NewsArticleResponse>> GetAll()
        {
            var newsArticles = await _repository.GetAll();
            return _mapper.Map<IEnumerable<NewsArticleResponse>>(newsArticles);
        }

        public async Task<bool> Update(int id, NewsArticleRequest newsArticleRequest)
        {
            var newsArticle = _mapper.Map<NewsArticle>(newsArticleRequest);
            return await _repository.Update(id, newsArticle);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }
        public async Task<DashboardStatistics> GetDashboardStatistics(string reportType, DateTime startDate, DateTime endDate)
        {
            var newsArticles = await _repository.GetAll();
            newsArticles = newsArticles.Where(a => a.CreatedDate >= startDate && a.CreatedDate <= endDate).ToList();

            var statistics = new DashboardStatistics
            {
                ActiveArticlesCount = newsArticles.Count(a => a.NewsStatus == "ACTIVE"),
                InactiveArticlesCount = newsArticles.Count(a => a.NewsStatus == "IN_ACTIVE")
            };

            if (reportType == "month")
            {
                statistics.ArticlesPublishedPerPeriod = newsArticles.GroupBy(a => new { a.CreatedDate.Year, a.CreatedDate.Month })
                                                                    .Select(g => new { g.Key.Year, g.Key.Month, Count = g.Count() })
                                                                    .ToDictionary(x => new DateTime(x.Year, x.Month, 1), x => x.Count);

                statistics.TotalArticlesPerPeriod = newsArticles.GroupBy(a => new { a.CreatedDate.Year, a.CreatedDate.Month })
                                                                .Select(g => new { g.Key.Year, g.Key.Month, Count = g.Count() })
                                                                .ToDictionary(x => new DateTime(x.Year, x.Month, 1), x => x.Count);
            }
            else
            {
                statistics.ArticlesPublishedPerPeriod = newsArticles.GroupBy(a => a.CreatedDate.Date)
                                                                    .Select(g => new { Date = g.Key, Count = g.Count() })
                                                                    .ToDictionary(x => x.Date, x => x.Count);

                statistics.TotalArticlesPerPeriod = newsArticles.GroupBy(a => a.CreatedDate.Date)
                                                                .Select(g => new { Date = g.Key, Count = g.Count() })
                                                                .ToDictionary(x => x.Date, x => x.Count);
            }

            return statistics;
        }

        public async Task<List<NewsArticleResponse>> GetRecentArticles(int count)
        {
            var newsArticles = await _repository.GetAll();
            var recentArticles = newsArticles.OrderByDescending(a => a.CreatedDate).Take(count).ToList();
            return _mapper.Map<List<NewsArticleResponse>>(recentArticles);
        }
    }
}