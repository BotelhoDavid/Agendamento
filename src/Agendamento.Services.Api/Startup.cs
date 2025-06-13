using Agendamento.Domain.Core.Settings;
using Agendamento.Domain.Core.Types;
using Agendamento.Infra.CrossCutting.IoC;
using Agendamento.Infra.CrossCutting.Swagger.Providers;
using Agendamento.Services.Api.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Collections;

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

            services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/");
                options.Conventions.AllowAnonymousToPage("/Login");
                options.Conventions.AllowAnonymousToPage("/Logout");
            });

            services.AddAuthorization();

            IDictionary _envVars = Environment.GetEnvironmentVariables();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddCustomJWTConfiguration(_configuration);

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
