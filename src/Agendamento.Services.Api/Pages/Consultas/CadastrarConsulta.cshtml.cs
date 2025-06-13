using Agendamento.Application.Interfaces;
using Agendamento.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;

namespace Agendamento.Services.Api.Pages
{
    public class CadastrarConsultaModel : PageModel
    {
        private readonly IConsultaAppService _consultaAppService;
        private readonly IMedicoAppService _medicoAppService;
        private readonly IPacienteAppService _pacienteAppService;

        public CadastrarConsultaModel(
            IConsultaAppService consultaAppService,
            IMedicoAppService medicoAppService,
            IPacienteAppService pacienteAppService)
        {
            _consultaAppService = consultaAppService;
            _medicoAppService = medicoAppService;
            _pacienteAppService = pacienteAppService;
        }

        [BindProperty]
        public CadastroConsultaViewModel CadastroConsulta { get; set; }

        public List<SelectListItem> Pacientes { get; set; } = new();
        public List<SelectListItem> Especialidades { get; set; } = new();

        public async Task OnGetAsync()
        {
            var pacientes = await _pacienteAppService.ObterPacientesAsync();
            Pacientes = pacientes.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Nome }).ToList();

            var especialidades = await _medicoAppService.ObterEspecialidadesAsync();
            Especialidades = especialidades.Select(e => new SelectListItem { Value = e, Text = e }).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync();
                return Page();
            }

            await _consultaAppService.CadastrarConsultaAsync(CadastroConsulta);
            return RedirectToPage("/Index");
        }

        public async Task<JsonResult> OnGetMedicosPorEspecialidadeAsync(string especialidade)
        {
            var medicos = await _medicoAppService.ObterMedicoPorEspecialidadeAsync(especialidade);
            var lista = medicos.Select(m => new { id = m.Id, nome = m.Nome }).ToList();
            return new JsonResult(lista);
        }

        public async Task<JsonResult> OnGetDatasDisponiveisAsync(Guid pacienteId)
        {
            var filtro = new FiltroPaginacaoBasicoViewModel(pacienteId);
            var consultas = await _consultaAppService.ObterConsultasPorIdAsync(filtro);

            var datasIndisponiveis = consultas
                .Select(c => DateOnly.FromDateTime(c.Data).ToString("yyyy-MM-dd"))
                .Distinct()
                .ToList();

            return new JsonResult(new
            {
                min = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd"),
                datasIndisponiveis = datasIndisponiveis
            });
        }


        public async Task<JsonResult> OnGetHorariosDisponiveisAsync(Guid medicoId, string data)
        {
            var filtro = new FiltroPaginacaoBasicoViewModel(medicoId);
            var consultas = await _consultaAppService.ObterConsultasPorIdAsync(filtro);

            var dataConsulta = DateOnly.ParseExact(data, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            var horariosIndisponiveis = consultas
                .Where(c => DateOnly.FromDateTime(c.Data) == dataConsulta)
                .Select(c => c.Horario)
                .ToList();

            var horariosPossiveis = new List<TimeSpan>();
            var inicio = new TimeSpan(8, 0, 0); // 08:00
            var fim = new TimeSpan(17, 0, 0);   // 17:00

            for (var horario = inicio; horario <= fim; horario = horario.Add(new TimeSpan(0, 30, 0)))
            {
                if (!horariosIndisponiveis.Contains(horario))
                    horariosPossiveis.Add(horario);
            }

            var teste = new JsonResult(horariosPossiveis.Select(h => h.ToString(@"hh\:mm")));
            return teste;
        }
    }
}
