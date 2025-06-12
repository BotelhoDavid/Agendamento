using Agendamento.Application.Interfaces;
using Agendamento.Application.ViewModels;
using Agendamento.Domain.Core.Enum;
using Agendamento.Infra.CrossCutting.ExceptionHandler.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Agendamento.Services.Api.Controllers
{
    public class ConsultasController : ApiController
    {
        private readonly IConsultaAppService _service;
        private readonly ILogger<ConsultasController> _logger;

        public ConsultasController(IConsultaAppService service,
                                   IServiceProvider serviceProvider,
                                   ILogger<ConsultasController> logger)
            : base(serviceProvider)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Filtrar pedidos.
        /// </summary>
        [HttpPost("filtro")]
        [ProducesResponseType(type: typeof(List<ConsultaViewModel>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> FiltrarConsultaAsync([FromBody] FiltroPaginacaoBasicoViewModel filtro)
        {
            List<ConsultaViewModel> _consulta = await _service.ObterConsultasPorIdAsync(filtro);

            return Ok(_consulta);
        }

        /// <summary>
        /// testar banco.
        /// </summary>
        [HttpGet("testar-banco")]
        public async Task<IActionResult> TestarBancoAsync()
        {
            bool _consulta = await _service.TestarBanco();

            return Response(_consulta);
        }


        /// <summary>
        /// Filtrar pedidos.
        /// </summary>

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] CadastroConsultaViewModel consulta)
        {
            await _service.CadastrarConsultaAsync(consulta);
            return Ok(new { message = "Consulta cadastrada com sucesso!" });
        }
    }
}
