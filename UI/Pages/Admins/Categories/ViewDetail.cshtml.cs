using BusinessLayer.Models.Responses;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace UI.Pages.Admins.Categories
{
    public class ViewDetailModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public ViewDetailModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public CategoryResponse Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Category = await _categoryService.GetById(id);
            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}