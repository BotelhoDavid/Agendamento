using Agendamento.Domain.Core.Enum;
using Agendamento.Domain.Core.Extensions;
using Agendamento.Infra.CrossCutting.Chain.Providers.HttpHandlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Agendamento.Services.Api.Controllers
{
    public abstract class ApiController : Controller
    {
        private readonly HttpResponseHandle _statusOk;

        public ApiController(IServiceProvider serviceProvider)
        {
            _statusOk = serviceProvider.GetImplementation<HttpResponseHandle, StatusOk>();
        }

        /// <summary>
        /// Método para padronização das respostas enviadas
        /// 
        /// Exemplo de utilização:
        ///     Response(_result, ApiErrorCodes.CODIGOERRO);
        /// </summary>
        /// <param name="result">Objeto da resposta</param>
        /// <param name="apiErrorCode">Código de erro (ApiErrorCodes) Default: UNEXPC</param>
        /// <param name="responseStatusCode">Código HTTP HttpStatusCode Default: OK (200)</param>
        /// <returns></returns>
        protected new IActionResult Response(object result = null,
                                             ApiErrorCodes apiErrorCode = ApiErrorCodes.UNEXPC,
                                             HttpStatusCode responseStatusCode = HttpStatusCode.OK)
        {

            return _statusOk.Handle(result, apiErrorCode, responseStatusCode);

        }
    }
}
