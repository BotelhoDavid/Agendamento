using Agendamento.Infra.CrossCutting.Swagger.Providers;
using Agendamento.Infra.CrossCutting.IoC;
using Agendamento.Services.Api.Configuration;
using Agendamento.Domain.Core.Types;
using Microsoft.Extensions.Configuration;
using Agendamento.Services.Api;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Adiciona Startup manualmente
        var startup = new Startup(builder.Configuration);
        startup.ConfigureServices(builder.Services);

        var app = builder.Build();

        startup.Configure(app, app.Environment);

        app.Run();

    }
}