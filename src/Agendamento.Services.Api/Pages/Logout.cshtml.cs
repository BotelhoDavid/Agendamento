using Azure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Services.Api.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            Response.Cookies.Delete("access_token");
            return RedirectToPage("/Login"); // ou outro local
        }
    }
}
