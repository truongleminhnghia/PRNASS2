using AutoMapper;
using BusinessLayer.Models.Requests;
using BusinessLayer.Models.Responses;
using DataAccessLayer.Entities;

namespace BusinessLayer.Automappers
{
    public class CategoryAutoMapper : Profile
    {
        public CategoryAutoMapper()
        {
            CreateMap<Category, CategoryRequest>().ReverseMap();
            CreateMap<Category, CategoryResponse>()
                .ForMember(dest => dest.ParentCategoryName, opt => opt.MapFrom(src => src.ParentCategory.CategoryName))
                .ForMember(dest => dest.ParentCategoryID, opt => opt.MapFrom(src => src.ParentCategoryID)) // Add this line
                .ReverseMap();
        }
    }
}