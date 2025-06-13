using AutoMapper;

namespace Agendamento.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(new DtoToViewModelMappingProfile());
                configuration.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
