using BusinessLayer.Models.Requests;
using BusinessLayer.Models.Responses;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace UI.Pages.Admins.accounts
{
    public class IndexModel : PageModel
    {

        private readonly ISystemAccountService _systemAccountService;

        public IndexModel(ISystemAccountService systemAccountService)
        {
            _systemAccountService = systemAccountService;
        }

        public IEnumerable<SystemAccountResponse> Accounts { get; set; } = new List<SystemAccountResponse>();

        [BindProperty]
        public SystemAccountRequest Account { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Accounts = await _systemAccountService.GetAll() ?? new List<SystemAccountResponse>();
            return Page(); 
        }

        public async Task<IActionResult> OnPostCreate()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _systemAccountService.CreateAccount(Account);

            if (result != null)
            {
                TempData["SuccessMessage"] = "Account created successfully!";
                return RedirectToPage("./Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to create account.");
                return Page();
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _systemAccountService.DeleteAccount(id);
            return RedirectToPage();
        }

    }
}
