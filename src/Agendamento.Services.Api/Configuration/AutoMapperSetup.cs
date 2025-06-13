using Agendamento.Application.AutoMapper;

namespace Agendamento.Services.Api.Configuration
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(AutoMapperConfig));

            AutoMapperConfig.RegisterMappings();
        }
    }
}
