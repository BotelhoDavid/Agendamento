using Agendamento.Application.Interfaces;
using Agendamento.Application.ViewModels;
using Agendamento.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agendamento.Services.Api.Pages
{
    public class CadastroPacienteModel : PageModel
    {
        private readonly IPacienteAppService _service;

        public CadastroPacienteModel(IPacienteAppService service)
        {
            _service = service;
        }

        [BindProperty]
        public CadastroPacienteViewModel paciente { get; set; } = new();

        public string Mensagem { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _service.CadastrarPaciente(paciente);

            Mensagem = "Paciente cadastrado com sucesso!";
            ModelState.Clear(); // limpa validações
            paciente = new();      // limpa os campos

            return Page();
        }
    }
}