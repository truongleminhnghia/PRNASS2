using BusinessLayer.Models;
using BusinessLayer.Models.Requests;
using BusinessLayer.Models.Responses;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UI.Pages.Admins.accounts
{
    public class IndexModel : PageModel
    {
        private readonly ISystemAccountService _accountService;

        public IndexModel(ISystemAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public SystemAccountRequest Account { get; set; }
        public IEnumerable<SystemAccountResponse> Accounts { get; set; }

        [BindProperty(SupportsGet = true)]
        public string StatusFilter { get; set; } = "ACTIVE";

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public string RoleFilter { get; set; }

        public async Task OnGetAsync()
        {
            Accounts = await _accountService.GetFilteredAccounts(StatusFilter, SearchTerm, RoleFilter);
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Failed to create account. Please check the input values.";
                return Page();
            }

            try
            {
                await _accountService.SaveAccount(Account);
                TempData["Message"] = "Account created successfully.";
            }
            catch
            {
                TempData["Message"] = "Failed to create account. Please try again.";
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _accountService.UpdateStatus(id);
            return RedirectToPage();
        }
    }
}