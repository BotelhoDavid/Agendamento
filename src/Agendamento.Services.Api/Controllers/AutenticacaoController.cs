using Agendamento.Application.Interfaces;
using Agendamento.Application.ViewModels;
using Agendamento.Domain.Core.Enum;
using Agendamento.Infra.CrossCutting.ExceptionHandler.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Services.Api.Controllers
{
    [Route("[controller]")]
    public class AutenticacaoController : ApiController
    {
        private readonly IAutenticacaoAppService _service;
        private readonly ILogger<ConsultasController> _logger;

        public AutenticacaoController(IAutenticacaoAppService service,
                                      IServiceProvider serviceProvider,
                                      ILogger<ConsultasController> logger)
            : base(serviceProvider)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Autenticar o usuario.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> AutenticarUsuarioAsync([FromBody] AutenticacaoViewModel autenticacaoViewModel)
        {
            if (!ModelState.IsValid)
                throw new ApiException(ApiErrorCodes.INVLOP);

            await _service.AutenticarAsync(autenticacaoViewModel.Email, autenticacaoViewModel.Password);

            return Ok();
        }
    }
}
