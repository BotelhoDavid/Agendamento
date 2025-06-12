using Microsoft.AspNetCore.Http;

namespace Agendamento.Infra.CrossCutting.Auth
{
    public class JwtCookieMiddleware
    {
        private readonly RequestDelegate _next;
        private const string TokenCookieName = "access_token";

        public JwtCookieMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Cookies.TryGetValue(TokenCookieName, out var token))
            {
                if (!context.Request.Headers.ContainsKey("Authorization"))
                {
                    context.Request.Headers.Append("Authorization", $"Bearer {token}");
                }
            }

            await _next(context);
        }
    }
}
