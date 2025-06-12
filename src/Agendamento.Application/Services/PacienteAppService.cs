using Agendamento.Application.Interfaces;
using Agendamento.Application.ViewModels;
using Agendamento.Domain.Core.Enum;
using Agendamento.Domain.Entities;
using Agendamento.Infra.CrossCutting.ExceptionHandler.Extensions;
using Agendamento.Infrastructure.Dapper.Interfaces;
using AutoMapper;

namespace Agendamento.Application.Services
{
    public class PacienteAppService : IPacienteAppService
    {
        private readonly IAgendamentoDapperManager _dapperAgendamento;
        private readonly IMapper _mapper;

        public PacienteAppService(IAgendamentoDapperManager dapperCliente,
                                  IMapper mapper)
        {
            _dapperAgendamento = dapperCliente;
            _mapper = mapper;
        }

        public async Task CadastrarPaciente(CadastroPacienteViewModel paciente)
        {
            Paciente _paciente = _mapper.Map<Paciente>(paciente);
            await _dapperAgendamento.CadastrarPacienteAsync(_paciente);
        }

        public IEnumerable<Paciente> ObterPacientes()
        {
            IEnumerable<Paciente> pacientes = new List<Paciente>() ?? throw new ApiException(ApiErrorCodes.USNOTFND);

            return pacientes;
        }
    }
}
