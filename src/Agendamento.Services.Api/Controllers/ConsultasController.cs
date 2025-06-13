using Agendamento.Application.Interfaces;
using Agendamento.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Services.Api.Controllers
{
    [Route("[controller]")]
    public class ConsultasController : ApiController
    {
        private readonly IConsultaAppService _service;

        public ConsultasController(IConsultaAppService service,
                                   IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            _service = service;
        }

        /// <summary>
        /// Filtrar Consultas.
        /// </summary>
        [HttpPost("filtro")]
        [ProducesResponseType(type: typeof(List<ConsultaViewModel>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> FiltrarConsultaAsync([FromBody] FiltroPaginacaoBasicoViewModel filtro)
        {
            List<ConsultaViewModel> _consulta = await _service.ObterConsultasPorIdAsync(filtro);

            return Ok(_consulta);
        }


        /// <summary>
        /// Cadastrar Consultas.
        /// </summary>
        [HttpPost("cadastrar")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> CadastrarAsync([FromBody] CadastroConsultaViewModel consulta)
        {
            await _service.CadastrarConsultaAsync(consulta);
            return Ok(new { message = "Consulta cadastrada com sucesso!" });
        }
    }
}
