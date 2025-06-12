using Microsoft.AspNetCore.Builder;

namespace Agendamento.Infra.CrossCutting.Auth
{
    public static class JwtCookieMiddlewareExtensions
    {
        public static IApplicationBuilder UseJwtCookieAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtCookieMiddleware>();
        }
    }
}
