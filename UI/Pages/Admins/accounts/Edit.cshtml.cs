using BusinessLayer.Models;
using BusinessLayer.Models.Requests;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace UI.Pages.Admins.accounts
{
    public class EditModel : PageModel
    {
        private readonly ISystemAccountService _accountService;

        public EditModel(ISystemAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public SystemAccountRequest Account { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var account = await _accountService.GetById(id);
            if (account == null)
            {
                return NotFound();
            }

            Account = new SystemAccountRequest
            {
                AccountName = account.AccountName,
                AccountEmail = account.AccountEmail,
                AccountRole = account.AccountRole,
                AccountPassword = account.AccountPassword,
                AccountStatus = account.AccountStatus
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var updated = await _accountService.Update(id, Account);
            if (!updated)
            {
                return NotFound();
            }

            return RedirectToPage("Index");
        }
    }
}