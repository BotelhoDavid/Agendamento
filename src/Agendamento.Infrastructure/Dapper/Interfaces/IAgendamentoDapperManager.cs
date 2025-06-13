using Agendamento.Domain.Core.DTO;
using Agendamento.Domain.Entities;

namespace Agendamento.Infrastructure.Dapper.Interfaces
{
    public interface IAgendamentoDapperManager
    {
        #region Autenticacao

        Task<UsuarioDTO> ObterUsuarioPorEmailAsync(string email);
        #endregion Autenticacao

        #region Consulta

        Task<List<ConsultaDTO>> FiltrarConsultasAsync(Guid? id, DateTime? data, TimeSpan? horario, int pagina, int itensPorPagina);
        Task CadastrarConsultaAsync(Consulta consulta);

        #endregion Consulta

        #region Paciente

        Task<List<PacienteDTO>> ObterPacientesAsync();
        Task CadastrarPacienteAsync(Paciente paciente);
        Task<bool> ValidarCPF(string cpf);

        #endregion Paciente

        #region Medicos

        Task<List<string>> ObterEspecialidadesAsync();
        Task<List<MedicoDTO>> ObterMedicoPorEspecialidadeAsync(string especialidade);

        #endregion Medicos
    }
}
