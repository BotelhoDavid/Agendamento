using Agendamento.Domain.Core.DTO;
using Agendamento.Domain.Entities;

namespace Agendamento.Infrastructure.Dapper.Interfaces
{
    public interface IAgendamentoDapperManager
    {

        Task<List<ConsultaDTO>> FiltrarConsultasAsync(Guid? id, DateTime? data, TimeSpan? horario, int pagina, int itensPorPagina);

        Task CadastrarConsultaAsync(Consulta consulta);

        Task CadastrarPacienteAsync(Paciente paciente);

        Task<bool> TestarConnectionsAsync();
    }
}
