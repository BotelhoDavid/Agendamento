using Agendamento.Application.Interfaces;
using Agendamento.Application.ViewModels;
using Agendamento.Domain.Core.DTO;
using Agendamento.Domain.Core.Enum;
using Agendamento.Infra.CrossCutting.ExceptionHandler.Extensions;
using Agendamento.Infrastructure.Dapper.Interfaces;
using AutoMapper;

namespace Agendamento.Application.Services
{
    public class MedicoAppService : IMedicoAppService
    {
        private readonly IAgendamentoDapperManager _dapperAgendamento;
        private readonly IMapper _mapper;

        public MedicoAppService(IAgendamentoDapperManager dapperCliente,
                                  IMapper mapper)
        {
            _dapperAgendamento = dapperCliente;
            _mapper = mapper;
        }

        public async Task<List<string>> ObterEspecialidadesAsync()
        {
            List<string> _especialidades = await _dapperAgendamento.ObterEspecialidadesAsync();

            if (!_especialidades.Any())
                return new List<string>();

            return _especialidades.Distinct().ToList();
        }

        public async Task<List<MedicoViewModel>> ObterMedicoPorEspecialidadeAsync(string especialidade)
        {
            List<MedicoDTO> _medicos = await _dapperAgendamento.ObterMedicoPorEspecialidadeAsync(especialidade) ?? throw new ApiException(ApiErrorCodes.NOTFND);

            if (!_medicos.Any())
                return new List<MedicoViewModel>();

            return _mapper.Map<List<MedicoViewModel>>(_medicos).ToList();
        }
    }
}
