using Agendamento.Application.ViewModels;
using Agendamento.Domain.Entities;
using AutoMapper;

namespace Agendamento.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CadastroConsultaViewModel, Consulta>();

            CreateMap<CadastroPacienteViewModel, Paciente>();
        }
    }
}
