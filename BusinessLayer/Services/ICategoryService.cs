using BusinessLayer.Models.Requests;
using BusinessLayer.Models.Responses;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync();
        public Task<CategoryResponse> GetCategoryByIdAsync(int id);
        public Task AddCategoryAsync(CategoryRequest categoryRequest);
        public Task UpdateCategoryAsync(CategoryRequest categoryRequest);
    }
}
