using Agendamento.Application.Interfaces;
using Agendamento.Application.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agendamento.Services.Api.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConsultaAppService _consultaService;

        public IndexModel(IConsultaAppService consultaService)
        {
            _consultaService = consultaService;
        }

        public List<ConsultaViewModel> Consultas { get; set; } = new();

        public async Task OnGetAsync()
        {
            Consultas = await _consultaService.ObterConsultasPorIdAsync(new FiltroPaginacaoBasicoViewModel());
        }
    }
}