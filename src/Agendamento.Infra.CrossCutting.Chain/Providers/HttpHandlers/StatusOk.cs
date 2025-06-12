using Microsoft.AspNetCore.Mvc;
using System.Net;
using Agendamento.Domain.Core.Enum;

namespace Agendamento.Infra.CrossCutting.Chain.Providers.HttpHandlers
{
    public class StatusOk : HttpResponseHandle
    {

        public override IActionResult Handle(object result, ApiErrorCodes apiErrorCode, HttpStatusCode statusCode)
        {
            if (statusCode == HttpStatusCode.OK)
            {
                return new OkObjectResult(result);
            }

            return ((HttpResponseHandle)Next).Handle(result, apiErrorCode, statusCode);

        }

    }
}
