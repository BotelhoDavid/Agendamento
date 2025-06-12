using Agendamento.Domain.Core.Enum;
using Agendamento.Domain.Core.Extensions;
using System.Net;

namespace Agendamento.Infra.CrossCutting.ExceptionHandler.Extensions
{
    public class ApiException : Exception
    {
        public ApiException() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messages">Mensagens de erro</param>
        /// <param name="apiErrorCode">C�digo de erro da API</param>
        /// <param name="httpStatusCode">C�digo HTTP</param>
        /// <param name="requestData">Objeto da resposta</param>
        public ApiException(ApiErrorCodes apiErrorCode = ApiErrorCodes.UNEXPC,
                            Dictionary<string, string> errorFields = null,
                            HttpStatusCode? httpStatusCode = null,
                            object requestData = null,
                            params string[] messages
            )
        {
            ErrorFields = errorFields;
            ApiErrorsCodes = new List<ApiErrorCodes> { apiErrorCode };
            RequestData = requestData;
            StatusCode = httpStatusCode ?? apiErrorCode.GetStatusCode();
            Messages = messages.Any() ? messages : new string[] { apiErrorCode.GetDescription() };
            Titles = new List<string> { apiErrorCode.GetTitle() };
        }

        public IEnumerable<string> Messages { get; set; }

        public IEnumerable<string> Titles { get; set; }

        public Dictionary<string, string> ErrorFields { get; set; }

        public IEnumerable<ApiErrorCodes> ApiErrorsCodes { get; set; }

        public object RequestData { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }

}
