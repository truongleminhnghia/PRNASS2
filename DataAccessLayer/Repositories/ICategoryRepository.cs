using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAllCategoriesAsync();
        public Task<Category> GetCategoryByIdAsync(int id);
    }
}
