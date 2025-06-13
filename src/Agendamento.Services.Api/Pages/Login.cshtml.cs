using Agendamento.Application.Interfaces;
using Agendamento.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agendamento.Services.Api.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAutenticacaoAppService _autenticacaoAppService;

        public LoginModel(IAutenticacaoAppService autenticacaoAppService)
        {
            _autenticacaoAppService = autenticacaoAppService;
        }

        [BindProperty]
        public AutenticacaoViewModel Input { get; set; }

        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var token = await _autenticacaoAppService.AutenticarAsync(Input.Email, Input.Password);

                if (string.IsNullOrEmpty(token))
                {
                    ModelState.AddModelError(string.Empty, "Email ou senha inválidos");
                    return Page();
                }

                Response.Cookies.Append("access_token", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Path = "/",
                    IsEssential = true
                });

                return RedirectToPage("/Index");
            }
            catch (Exception err)
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro inesperado. Tente novamente mais tarde.");
                return Page();
            }
        }
    }
}