using AutoMapper;
using BusinessLayer.Models.Responses;
using DataAccessLayer.Entities;

namespace BusinessLayer.Automappers
{
    public class TagAutoMapper : Profile
    {
        public TagAutoMapper()
        {
            CreateMap<Tag, TagResponse>()
                .ForMember(dest => dest.TagName, opt => opt.MapFrom(src => src.TagName))
                .ReverseMap()
                .ForMember(dest => dest.TagName, opt => opt.MapFrom(src => src.TagName));
        }
    }
}