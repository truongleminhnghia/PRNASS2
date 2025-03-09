using BusinessLayer.Models.Requests;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages
{
	public class loginModel : PageModel
	{
		private readonly ISystemAccountService _systemAccountService;
		private readonly IConfiguration _configuration;

		public loginModel(ISystemAccountService systemAccountService, IConfiguration configuration)
		{
			_systemAccountService = systemAccountService;
			_configuration = configuration;
		}

		[BindProperty]
		public LoginRequest Login { get; set; } = new LoginRequest();

		public string ErrorMessage { get; set; }
		public void OnGet()
		{
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				ErrorMessage = "Vui lòng nhập email và mật khẩu!";
				return Page();
			}

			string savedEmail = _configuration["UserConfig:Email"];
			string savedPassword = _configuration["UserConfig:Password"];
			string savedRole = _configuration["UserConfig:AccountRole"];

			if (string.IsNullOrEmpty(savedEmail) || string.IsNullOrEmpty(savedPassword))
			{
				ErrorMessage = "Cấu hình tài khoản trong appsettings.json chưa đúng!";
				return Page();
			}

			if (Login.Email == savedEmail && Login.Password == savedPassword)
			{
				HttpContext.Session.SetString("UserEmail", Login.Email);
				if (savedRole.Equals("ADMIN"))
				{
					return RedirectToPage("/Admins/Dashboard");
				}
				return RedirectToPage("/Index");
			}
			else
			{
				ErrorMessage = "Email hoặc mật khẩu không đúng!";
				return Page();
			}
		}
	}
}
