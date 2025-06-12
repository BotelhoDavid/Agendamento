using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Agendamento.Infra.CrossCutting.Swagger.Providers
{
    /// <summary>
    /// Refer?ncias: https://github.com/domaindrivendev/Swashbuckle.AspNetCore
    /// </summary>
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services, string version = "v1")
        {
            return services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(name: $"{version}",
                                   info: new OpenApiInfo
                                   {
                                       Title = "Agendamento API",
                                       Version = $"{version}",
                                       Description = "API REST desenvolvida com .NET 8.0 para a aplicação <b>Agendamento</b>."
                                   });

                options.AddSecurityDefinition(name: "Bearer",
                                              securityScheme: new OpenApiSecurityScheme
                                              {
                                                  In = ParameterLocation.Header,
                                                  Type = SecuritySchemeType.ApiKey,
                                                  Name = "Authorization",
                                                  Description = "Utilização: Escreva 'Bearer {seuToken}'"
                                              });

                options.AddSecurityDefinition(name: "ApiKey",
                                              securityScheme: new OpenApiSecurityScheme
                                              {
                                                  In = ParameterLocation.Query,
                                                  Type = SecuritySchemeType.ApiKey,
                                                  Name = "api-key",
                                                  Description = "Utilização: Cole sua '{apiKey}'"
                                              });

                options.AddSecurityRequirement(securityRequirement: new OpenApiSecurityRequirement
                                                                    {
                                                                        {
                                                                            new OpenApiSecurityScheme
                                                                            {
                                                                                Reference = new OpenApiReference
                                                                                {
                                                                                    Id = "Bearer",
                                                                                    Type = ReferenceType.SecurityScheme
                                                                                }
                                                                            },new List<string>()
                                                                        }
                                                                    });

                options.AddSecurityRequirement(securityRequirement: new OpenApiSecurityRequirement
                                                                    {
                                                                        {
                                                                            new OpenApiSecurityScheme
                                                                            {
                                                                                Reference = new OpenApiReference
                                                                                {
                                                                                    Id = "ApiKey",
                                                                                    Type = ReferenceType.SecurityScheme
                                                                                }
                                                                            },new List<string>()
                                                                        }
                                                                    });
            });
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app, string version = "v1")
        {
            return app.UseSwagger(c =>
            {
                c.RouteTemplate = "api/v1/agendamento/documentation/{documentName}/swagger.json";
            })
                        .UseSwaggerUI(args =>
                        {
                            /* Rota para acessar a documentação */
                            args.RoutePrefix = "api/v1/agendamento/documentation";

                            /* Não alterar: Configuração aplicável tanto para servidor quanto para localhost */
                            args.SwaggerEndpoint("./v1/swagger.json", "Documentação API v1");

                            args.DocumentTitle = "Agendamento API - Swagger UI";

                            args.DisplayRequestDuration();

                            args.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                        });
        }
    }
}
