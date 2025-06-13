using Agendamento.Domain.Core.Enum;
using Agendamento.Infra.CrossCutting.ExceptionHandler.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Agendamento.Infra.CrossCutting.Chain.Providers.HttpHandlers
{
    public class StatusInternalServerError : HttpResponseHandle
    {

        public override IActionResult Handle(object result, ApiErrorCodes apiErrorCode, HttpStatusCode statusCode)
        {
            if (statusCode == HttpStatusCode.InternalServerError)
            {
                throw new ApiException(requestData: result, apiErrorCode: apiErrorCode, httpStatusCode: statusCode);
            }

            return ((HttpResponseHandle)Next).Handle(result, apiErrorCode, statusCode);
        }
    }
}
