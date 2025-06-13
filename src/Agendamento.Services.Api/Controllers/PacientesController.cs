using Agendamento.Application.Interfaces;
using Agendamento.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Services.Api.Controllers
{
    [Route("[controller]")]
    public class PacientesController : ApiController
    {
        private readonly IPacienteAppService _service;

        public PacientesController(IPacienteAppService service,
                                   IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            _service = service;
        }

        /// <summary>
        /// Obter Pacientes.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterPacientesAsync()
        {
            return Ok(await _service.ObterPacientesAsync());

        }

        /// <summary>
        /// Cadastrar Paciente.
        /// </summary>
        [HttpPost("cadastrar")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> CadastrarPaciente([FromBody] CadastroPacienteViewModel paciente)
        {
            await _service.CadastrarPacienteAsync(paciente);

            return Ok();
        }
    }
}
