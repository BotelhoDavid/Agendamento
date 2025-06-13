using Agendamento.Application.Interfaces;
using Agendamento.Domain.Core.Enum;
using Agendamento.Infra.CrossCutting.ExceptionHandler.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Services.Api.Controllers
{
    [Route("[controller]")]
    public class MedicosController : ApiController
    {
        private readonly IMedicoAppService _service;
        private readonly ILogger<ConsultasController> _logger;

        public MedicosController(IMedicoAppService service,
                                 IServiceProvider serviceProvider,
                                 ILogger<ConsultasController> logger)
            : base(serviceProvider)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Obter Especialidades.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(type: typeof(List<string>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterEspecialidades()
        {
            if (!ModelState.IsValid)
                throw new ApiException(ApiErrorCodes.INVLOP);

            return Ok(await _service.ObterEspecialidadesAsync());
        }

        /// <summary>
        /// Obter Medicos por Especialidade.
        /// </summary>
        [HttpGet("especialidades/{especialidade}")]
        [ProducesResponseType(type: typeof(List<string>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterMedicosPorEspecialidade(string especialidade)
        {
            if (!ModelState.IsValid)
                throw new ApiException(ApiErrorCodes.INVLOP);

            return Ok(await _service.ObterMedicoPorEspecialidadeAsync(especialidade));
        }
    }
}
