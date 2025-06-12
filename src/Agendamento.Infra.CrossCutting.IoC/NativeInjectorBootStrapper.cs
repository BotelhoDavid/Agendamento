using Agendamento.Application.Interfaces;
using Agendamento.Application.Services;
using Agendamento.Infra.CrossCutting.Chain.Extensions;
using Agendamento.Infra.CrossCutting.Chain.Providers.HttpHandlers;
using Agendamento.Infrastructure.Context;
using Agendamento.Infrastructure.Dapper;
using Agendamento.Infrastructure.Dapper.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Agendamento.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<AgendamentoContext>();

            services.ConfigureChain<HttpResponseHandle>(new StatusOk())
                    .Next(new StatusAccepted())
                    .Next(new StatusCreated())
                    .Next(new StatusNoContent())
                    .Next(new StatusNotFound())
                    .Next(new StatusForbidden())
                    .Next(new StatusBadRequest())
                    .Next(new StatusUnauthorized())
                    .Next(new StatusInternalServerError())
                    .Next(new StatusConflict())
                    .Next(new DefaultStatus());

            #region AppServices

            services.AddScoped<IConsultaAppService, ConsultaAppService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IPacienteAppService, PacienteAppService>();

            #endregion

            #region Dapper

            services.AddScoped<IAgendamentoDapperManager, AgendamentoDapperManager>();

            #endregion Dapper


        }
    }
}
