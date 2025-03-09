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
    public class NewsTagService : INewTagService
    {
        private readonly INewsTagRepository _newsTagRepository;
        private readonly IMapper _mapper;

        public NewsTagService(INewsTagRepository newsTagRepository, IMapper mapper)
        {
            _newsTagRepository = newsTagRepository;
            _mapper = mapper;
        }
        public async Task<List<NewsTagResponse>> GetTagsByArticleIdAsync(int articleId)
        {
            var tags = await _newsTagRepository.GetTagsByArticleIdAsync(articleId);
            return _mapper.Map<List<NewsTagResponse>>(tags);
        }
    }
}
