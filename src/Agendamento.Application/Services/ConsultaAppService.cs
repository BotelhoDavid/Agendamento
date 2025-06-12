using Agendamento.Application.Interfaces;
using Agendamento.Application.ViewModels;
using Agendamento.Domain.Core.DTO;
using Agendamento.Domain.Core.Enum;
using Agendamento.Domain.Entities;
using Agendamento.Infra.CrossCutting.ExceptionHandler.Extensions;
using Agendamento.Infrastructure.Dapper.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Application.Services
{
    public class ConsultaAppService : IConsultaAppService
    {
        private readonly IAgendamentoDapperManager _dapperAgendamento;
        private readonly IMapper _mapper;

        public ConsultaAppService(IAgendamentoDapperManager dapperCliente,
                                  IMapper mapper)
        {
            _dapperAgendamento = dapperCliente;
            _mapper = mapper;
        }

        public async Task<List<ConsultaViewModel>> ObterConsultasPorIdAsync(FiltroPaginacaoBasicoViewModel filtro)
        {
            List<ConsultaDTO> _consultas = await _dapperAgendamento.FiltrarConsultasAsync(id: filtro.Id,
                                                                                          data: filtro.Data,
                                                                                          //horario: TimeSpan.Parse(filtro.Horario),
                                                                                          horario: filtro.Horario,
                                                                                          pagina: filtro.Pagina,
                                                                                          itensPorPagina: filtro.ItensPorPagina) ?? throw new ApiException(ApiErrorCodes.NOTFND);

            if (!_consultas.Any())
                return new List<ConsultaViewModel>();

            return _consultas.Select(consulta => ToViewModel(consulta)).ToList();
        }

        public async Task CadastrarConsultaAsync(CadastroConsultaViewModel consulta)
        {
            Consulta _consulta = _mapper.Map<Consulta>(consulta);
            await _dapperAgendamento.CadastrarConsultaAsync(_consulta);
        }

        public async Task<bool> TestarBanco()
        {
            return await _dapperAgendamento.TestarConnectionsAsync();
        }

        private ConsultaViewModel ToViewModel(ConsultaDTO dto)
        {
            return new ConsultaViewModel
            {
                Id = Guid.NewGuid(), // Se não houver ID na DTO, pode gerar aqui ou adaptar
                Data = dto.Data,
                Horario = dto.Horario,
                Especialidade = dto.Especialidade,

                Paciente = new PacienteViewModel
                {
                    Id = dto.PacienteId,
                    Nome = dto.PacienteNome,
                    CPF = dto.CPF,
                    DataNascimento = dto.DataNascimento
                },

                Medico = new MedicoViewModel
                {
                    Id = dto.MedicoId,
                    Nome = dto.MedicoNome,
                    CRM = dto.CRM,
                    Especialidade = dto.MedicoEspecialidade,
                }
            };
        }
    }
}
