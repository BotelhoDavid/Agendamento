using Agendamento.Domain.Core.Enum;
using Agendamento.Domain.Core.Settings;
using Agendamento.Domain.Core.Types;
using Agendamento.Infra.CrossCutting.ExceptionHandler.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Agendamento.Services.Api.Configuration
{
    public static class JWTConfiguration
    {
        public static AuthenticationBuilder AddCustomJWTConfiguration(this AuthenticationBuilder authenticationBuilder, IConfiguration configuration)
        {
            try
            {
                TokenConfigurationsSettings _tokenConfigurations = configuration.GetSection(nameof(TokenConfigurationsSettings))?.Get<TokenConfigurationsSettings>();

                if (_tokenConfigurations == null)
                    throw new ApiException(ApiErrorCodes.APKYCONFGREQ);

                authenticationBuilder.AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_tokenConfigurations.Secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = true,
                        AuthenticationType = AuthenticationTypes.JWTBearer,
                        ValidateLifetime = true,
                        ValidIssuer = "Agendamento",
                        ValidAudience = "Agendamento"
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Cookies["access_token"];
                            if (!string.IsNullOrEmpty(accessToken))
                            {
                                context.Token = accessToken;
                            }
                            return Task.CompletedTask;
                        }
                    };
                });

                return authenticationBuilder;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
