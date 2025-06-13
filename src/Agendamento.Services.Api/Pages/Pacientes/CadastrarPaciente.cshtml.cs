using Agendamento.Application.Interfaces;
using Agendamento.Application.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agendamento.Services.Api.Pages
{
    public class CadastrarPacienteModel : PageModel
    {
        private readonly IPacienteAppService _pacienteAppService;
        private readonly IMapper _mapper;

        public CadastrarPacienteModel(IPacienteAppService pacienteAppService,
                                  IMapper mapper)
        {
            _pacienteAppService = pacienteAppService;
            _mapper = mapper;
        }

        [BindProperty]
        public CadastroPacienteViewModel Paciente { get; set; } = new CadastroPacienteViewModel();

        public void OnGet()
        {
            // Inicializa o modelo vazio ao carregar a p�gina
            Paciente = new CadastroPacienteViewModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Aqui voc� faria a persist�ncia no banco (exemplo: salvar paciente)

            // Simulando gera��o do Id
            await _pacienteAppService.CadastrarPacienteAsync(Paciente);
            return RedirectToPage("/Index");
        }
    }
}
