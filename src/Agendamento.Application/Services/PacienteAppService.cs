using Agendamento.Application.Interfaces;
using Agendamento.Application.ViewModels;
using Agendamento.Domain.Core.DTO;
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

        public async Task CadastrarPacienteAsync(CadastroPacienteViewModel paciente)
        {
            if (await _dapperAgendamento.ValidarCPF(paciente.CPF))
                throw new ApiException(ApiErrorCodes.NOTFND);

            Paciente _paciente = _mapper.Map<Paciente>(paciente);
            await _dapperAgendamento.CadastrarPacienteAsync(_paciente);
        }

        public async Task<List<PacienteViewModel>> ObterPacientesAsync()
        {
            List<PacienteDTO> _pacientes = await _dapperAgendamento.ObterPacientesAsync() ?? throw new ApiException(ApiErrorCodes.NOTFND);

            if (!_pacientes.Any())
                return new List<PacienteViewModel>();

            return _mapper.Map<List<PacienteViewModel>>(_pacientes);
        }
    }
}
