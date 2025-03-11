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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryResponse> SaveCategory(CategoryRequest categoryRequest)
        {
            var category = _mapper.Map<Category>(categoryRequest);
            var savedCategory = await _repository.SaveCategory(category);
            return _mapper.Map<CategoryResponse>(savedCategory);
        }

        public async Task<CategoryResponse?> GetById(int id)
        {
            var category = await _repository.GetById(id);
            return category == null ? null : _mapper.Map<CategoryResponse>(category);
        }

        public async Task<IEnumerable<CategoryResponse>> GetAll()
        {
            var categories = await _repository.GetAll();
            return _mapper.Map<IEnumerable<CategoryResponse>>(categories);
        }

        public async Task<IEnumerable<CategoryResponse>> GetFilteredCategories(string status, string searchTerm)
        {
            var categories = await _repository.GetAll();

            if (!string.IsNullOrEmpty(status))
            {
                categories = categories.Where(c => c.IsActive == (status == "ACTIVE"));
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                categories = categories.Where(c => c.CategoryName.Contains(searchTerm) || c.CategoryDescription.Contains(searchTerm));
            }

            return _mapper.Map<IEnumerable<CategoryResponse>>(categories.OrderBy(c => c.CategoryName));
        }

        public async Task<bool> Update(int id, CategoryRequest categoryRequest)
        {
            var category = _mapper.Map<Category>(categoryRequest);
            return await _repository.Update(id, category);
        }

        public async Task<bool> UpdateStatus(int id)
        {
            return await _repository.UpdateStatus(id);
        }
    }
}
