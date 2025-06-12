using Microsoft.AspNetCore.Mvc;
using System.Net;
using Agendamento.Domain.Core.Enum;
using Agendamento.Infra.CrossCutting.ExceptionHandler.Extensions;

namespace Agendamento.Infra.CrossCutting.Chain.Providers.HttpHandlers
{
    public class StatusConflict : HttpResponseHandle
    {

        public override IActionResult Handle(object result, ApiErrorCodes apiErrorCode, HttpStatusCode statusCode)
        {
            if (statusCode == HttpStatusCode.Conflict)
            {
                throw new ApiException(requestData: result, apiErrorCode: apiErrorCode, httpStatusCode: statusCode);
            }

            return ((HttpResponseHandle)Next).Handle(result, apiErrorCode, statusCode);
        }
    }
}
