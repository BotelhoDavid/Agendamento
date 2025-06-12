using Agendamento.Domain.Core.Enum;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Agendamento.Infra.CrossCutting.Chain.Providers.HttpHandlers
{
    public abstract class HttpResponseHandle : ChainBase
    {
        public abstract IActionResult Handle(object result, ApiErrorCodes apiErrorCode, HttpStatusCode statusCode);
    }
}
