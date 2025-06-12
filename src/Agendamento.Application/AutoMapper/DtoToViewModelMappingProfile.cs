using Agendamento.Application.ViewModels;
using Agendamento.Domain.Core.DTO;
using AutoMapper;

namespace Agendamento.Application.AutoMapper
{
    class DtoToViewModelMappingProfile : Profile
    {
        public DtoToViewModelMappingProfile()
        {
            CreateMap<ConsultaDTO, ConsultaViewModel>();

            CreateMap<PacienteDTO, PacienteViewModel>();

            CreateMap<MedicoDTO, MedicoViewModel>();
        }
    }
}
