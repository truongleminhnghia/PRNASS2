using BusinessLayer.Models.Requests;
using BusinessLayer.Models.Responses;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace UI.Pages.Admins.accounts
{
    public class ViewDetailModel : PageModel
    {
        private readonly ISystemAccountService _systemAccountService;

        public ViewDetailModel(ISystemAccountService systemAccountService)
        {
            _systemAccountService = systemAccountService;
        }

        [BindProperty]
        public SystemAccountRequest AccountRequest { get; set; } = new SystemAccountRequest();

        public SystemAccountResponse Account { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool Edit { get; set; } = false;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Account = await _systemAccountService.GetById(id);

            if (Account == null)
            {
                return NotFound();
            }

            // Luôn đảm bảo dữ liệu hiển thị trong form, kể cả khi không Edit
            AccountRequest.AccountName = Account.AccountName;
            AccountRequest.AccountEmail = Account.AccountEmail;
            AccountRequest.AccountStatus = Account.AccountStatus;
            AccountRequest.AccountRole = Account.AccountRole;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _systemAccountService.Update(id, AccountRequest);

            return RedirectToPage("ViewDetail", new { id });
        }
    }
}
