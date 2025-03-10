using AutoMapper;
using BusinessLayer.Models.Responses;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync()
        {
            var category = await _categoryRepository.GetAllCategoriesAsync();
            if (category == null)
            {
                throw new Exception("List empty!");
            }
            return _mapper.Map<IEnumerable<CategoryResponse>>(category);

        }

        public async Task<CategoryResponse> GetCategoryByIdAsync(int id)
        {
            var result = await _categoryRepository.GetCategoryByIdAsync(id);
            if (result != null)
            {
                return _mapper.Map<CategoryResponse>(result);
            }
            throw new Exception("Account do not exist");
        }
    }
}
