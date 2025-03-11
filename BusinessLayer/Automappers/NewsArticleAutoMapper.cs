using AutoMapper;
using BusinessLayer.Models.Requests;
using BusinessLayer.Models.Responses;
using DataAccessLayer.Entities;
using System.Linq;

namespace BusinessLayer.Automappers
{
    public class NewsArticleAutoMapper : Profile
    {
        public NewsArticleAutoMapper()
        {
            CreateMap<NewsArticle, NewsArticleRequest>().ReverseMap();
            CreateMap<NewsArticle, NewsArticleResponse>()
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.NewsTags.Select(nt => nt.Tag.TagName)))
                .ReverseMap();
        }
    }
}
