using BusinessLayer.Models.Requests;
using BusinessLayer.Models.Responses;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UI.Pages.Admins.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public IndexModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [BindProperty]
        public CategoryRequest Category { get; set; }
        public IEnumerable<CategoryResponse> Categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public string StatusFilter { get; set; } = "ACTIVE";

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public async Task OnGetAsync()
        {
            Categories = await _categoryService.GetFilteredCategories(StatusFilter, SearchTerm);
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Failed to create category. Please check the input values.";
                Categories = await _categoryService.GetFilteredCategories(StatusFilter, SearchTerm);
                return Page();
            }

            try
            {
                await _categoryService.SaveCategory(Category);
                TempData["Message"] = "Category created successfully.";
            }
            catch
            {
                TempData["Message"] = "Failed to create category. Please try again.";
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            try
            {
                await _categoryService.UpdateStatus(id);
                TempData["Message"] = "Category status updated successfully.";
            }
            catch
            {
                TempData["Message"] = "Failed to update category status. Please try again.";
            }

            return RedirectToPage();
        }
    }
}