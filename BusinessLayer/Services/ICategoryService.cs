using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models.Requests;
using BusinessLayer.Models.Responses;

namespace BusinessLayer.Services
{
    public interface ICategoryService
    {
        Task<CategoryResponse> SaveCategory(CategoryRequest categoryRequest);
        Task<CategoryResponse?> GetById(int id);
        Task<IEnumerable<CategoryResponse>> GetAll();
        Task<IEnumerable<CategoryResponse>> GetFilteredCategories(string status, string searchTerm);
        Task<bool> Update(int id, CategoryRequest categoryRequest);
        Task<bool> UpdateStatus(int id);
    }
}
