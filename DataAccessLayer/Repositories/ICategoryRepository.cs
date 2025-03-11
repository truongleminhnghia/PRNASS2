using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> SaveCategory(Category category);
        Task<Category?> GetById(int id);
        Task<IEnumerable<Category>> GetAll();
        Task<bool> Update(int id, Category category);
        Task<bool> UpdateStatus(int id);
    }
}
