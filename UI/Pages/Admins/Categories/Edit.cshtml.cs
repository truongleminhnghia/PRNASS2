using BusinessLayer.Models.Requests;
using BusinessLayer.Models.Responses;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UI.Pages.Admins.Categories
{
    public class EditModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public EditModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [BindProperty]
        public CategoryRequest Category { get; set; }
        public IEnumerable<CategoryResponse> Categories { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            Category = new CategoryRequest
            {
                CategoryName = category.CategoryName,
                CategoryDescription = category.CategoryDescription,
                ParentCategoryID = category.ParentCategoryID,
                IsActive = category.IsActive
            };

            Categories = await _categoryService.GetAll();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                Categories = await _categoryService.GetAll();
                return Page();
            }

            try
            {
                await _categoryService.Update(id, Category);
                TempData["Message"] = "Category updated successfully.";
            }
            catch
            {
                TempData["Message"] = "Failed to update category. Please try again.";
            }

            return RedirectToPage("Index");
        }
    }
}