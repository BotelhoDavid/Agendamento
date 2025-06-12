using System.Net;

namespace Agendamento.Domain.Core.Attributes
{
    public sealed class HttpStatusCodeAttribute : Attribute
    {
        public HttpStatusCode HttpStatusCode { get; }

        public HttpStatusCodeAttribute(int statusCode)
        {
            HttpStatusCode = (HttpStatusCode)statusCode;
        }
    }
}
