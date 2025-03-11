using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> SaveCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> GetById(int id)
        {
            return await _context.Categories.Include(c => c.ParentCategory).FirstOrDefaultAsync(c => c.CategoryID == id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.Include(c => c.ParentCategory).ToListAsync();
        }

        public async Task<bool> Update(int id, Category category)
        {
            var existingCategory = await _context.Categories.FindAsync(id);
            if (existingCategory == null)
            {
                return false;
            }

            existingCategory.CategoryName = category.CategoryName;
            existingCategory.CategoryDescription = category.CategoryDescription;
            existingCategory.ParentCategoryID = category.ParentCategoryID;
            existingCategory.IsActive = category.IsActive;

            _context.Categories.Update(existingCategory);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateStatus(int id)
        {
            var existingCategory = await _context.Categories.FindAsync(id);
            if (existingCategory == null)
            {
                return false;
            }

            existingCategory.IsActive = !existingCategory.IsActive;
            _context.Categories.Update(existingCategory);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
