using Agendamento.Domain.Core.Settings;
using Agendamento.Domain.Core.Types;
using Agendamento.Infra.CrossCutting.Auth;
using Agendamento.Infra.CrossCutting.IoC;
using Agendamento.Services.Api.Configuration;
using Agendamento.Infra.CrossCutting.Swagger.Providers;
using Microsoft.Extensions.Hosting;

namespace Agendamento.Services.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApplicationSettings>(_configuration.GetSection(nameof(ApplicationSettings)));
            services.Configure<TokenConfigurationsSettings>(_configuration.GetSection(nameof(TokenConfigurationsSettings)));

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddSwaggerConfiguration();

            services.AddAutoMapperSetup();

            services.AddRazorPages();

            services.AddAuthorization();

            services.AddAuthentication();

            NativeInjectorBootStrapper.RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerConfiguration();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseJwtCookieAuthentication();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
