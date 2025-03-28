﻿using BusinessLayer.Models;
using BusinessLayer.Models.Responses;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace UI.Pages.Admins.accounts
{
    public class ViewDetailModel : PageModel
    {
        private readonly ISystemAccountService _accountService;

        public ViewDetailModel(ISystemAccountService accountService)
        {
            _accountService = accountService;
        }

        public SystemAccountResponse Account { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Account = await _accountService.GetById(id);
            if (Account == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}