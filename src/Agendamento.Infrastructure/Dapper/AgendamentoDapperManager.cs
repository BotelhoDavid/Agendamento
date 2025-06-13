using Agendamento.Domain.Core.DTO;
using Agendamento.Domain.Core.Types;
using Agendamento.Domain.Entities;
using Agendamento.Infra.CrossCutting.Dapper;
using Agendamento.Infrastructure.Context;
using Agendamento.Infrastructure.Dapper.Interfaces;
using Dapper;
using Microsoft.Extensions.Options;

namespace Agendamento.Infrastructure.Dapper
{
    public class AgendamentoDapperManager : DapperBase, IAgendamentoDapperManager
    {
        public AgendamentoDapperManager(IOptions<ApplicationSettings> options)
           : base(AgendamentoContext.GetConnectionStringFromEnvironment(),
                  options)
        {
        }

        #region Autenticacao

        public async Task<UsuarioDTO> ObterUsuarioPorEmailAsync(string email)
        {
            string sql = @"
                           SELECT 
                                Usuario.Id, Usuario.Nome, Usuario.Email, Usuario.SenhaHash                       
                            FROM Usuario
                            WHERE Usuario.Email = @Email;";

            var parametros = new
            {
                email
            };

            return await ExecuteFindAsync<UsuarioDTO>(sql, parametros);
        }

        #endregion Autenticacao

        #region Consulta

        public async Task<List<ConsultaDTO>> FiltrarConsultasAsync(Guid? id, DateTime? data, TimeSpan? horario, int pagina, int itensPorPagina)
        {
            int offset = pagina * itensPorPagina;

            var parametros = new DynamicParameters();
            parametros.Add("@Offset", offset);
            parametros.Add("@PageSize", itensPorPagina);

            var whereClause = new List<string>();

            if (id.HasValue)
            {
                whereClause.Add("(Consulta.MedicoId = @Id OR Consulta.PacienteId = @Id)");
                parametros.Add("@Id", id.Value);
            }

            if (data.HasValue)
            {
                whereClause.Add("CAST(Consulta.Data AS DATE) = @Data");
                parametros.Add("@Data", data.Value);
            }

            if (horario.HasValue)
            {
                whereClause.Add("CAST(Consulta.Horario AS TIME) = @Horario");
                parametros.Add("@Horario", horario.Value);
            }

            string whereSql = whereClause.Count > 0
                ? "WHERE " + string.Join(" AND ", whereClause)
                : string.Empty;

            string query = $@"
                            SELECT 
                                Consulta.Data, Consulta.Horario, Consulta.Especialidade,
                                Paciente.Id AS PacienteId, Paciente.Nome AS PacienteNome, Paciente.CPF, Paciente.DataNascimento,
                                Medico.Id AS MedicoId, Medico.Nome AS MedicoNome, Medico.Especialidade AS MedicoEspecialidade, Medico.CRM
                            FROM Consulta
                            INNER JOIN Paciente ON Consulta.PacienteId = Paciente.Id
                            INNER JOIN Medico ON Consulta.MedicoId = Medico.Id
                            {whereSql}
                            ORDER BY Consulta.Data
                            OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;";

            return ExecuteQueryAsync<ConsultaDTO>(query, parametros).Result.ToList();
        }

        public async Task CadastrarConsultaAsync(Consulta consulta)
        {
            string sql = @"
            INSERT INTO Consulta (Id, MedicoId, PacienteId, Data, Horario, Especialidade)
            VALUES (@Id, @MedicoId, @PacienteId, @Data, @Horario, @Especialidade);";

            var parametros = new
            {
                Id = Guid.NewGuid(),
                consulta.MedicoId,
                consulta.PacienteId,
                consulta.Data,
                consulta.Horario,
                consulta.Especialidade
            };

            await ExecuteCreateAsync(sql, parametros);
        }

        #endregion Consulta

        #region Medico

        public async Task<List<string>> ObterEspecialidadesAsync()
        {
            string sql = @"
                           SELECT 
                                Medico.Especialidade
                           FROM Medico";

            return (List<string>)await ExecuteQueryAsync<string>(sql, null);
        }

        public async Task<List<MedicoDTO>> ObterMedicoPorEspecialidadeAsync(string especialidade)
        {
            string sql = @"
                           SELECT 
                                Medico.Id, Medico.Nome, Medico.Especialidade, Medico.CRM
                           FROM Medico
                           WHERE Medico.Especialidade = @Especialidade";

            var parametros = new
            {
                especialidade
            };

            return (List<MedicoDTO>)await ExecuteQueryAsync<MedicoDTO>(sql, parametros);
        }

        #endregion Medico

        #region Paciente

        public async Task CadastrarPacienteAsync(Paciente paciente)
        {
            const string sql = @"
                               INSERT INTO Paciente (Id, Nome, CPF, DataNascimento, DataCadastro)
                               VALUES (@Id, @Nome, @CPF, @DataNascimento, @DataCadastro);";

            var parametros = new
            {
                Id = paciente.Id == Guid.Empty ? Guid.NewGuid() : paciente.Id,
                paciente.Nome,
                paciente.CPF,
                paciente.DataNascimento,
                DataCadastro = paciente.DataCadastro == default ? DateTime.UtcNow : paciente.DataCadastro
            };

            await ExecuteCreateAsync(sql, parametros);
        }

        public async Task<List<PacienteDTO>> ObterPacientesAsync()
        {

            string sql = @"
                           SELECT 
                                Paciente.Id, Paciente.Nome, Paciente.CPF, Paciente.DataNascimento
                           FROM Paciente";

            return (List<PacienteDTO>)await ExecuteQueryAsync<PacienteDTO>(sql, null);
        }

        public async Task<bool> ValidarCPF(string cpf)
        {

            string sql = @"
                           SELECT 
                                Paciente.Id, Paciente.Nome, Paciente.CPF, Paciente.DataNascimento
                           FROM Paciente
                           WHERE Paciente.CPF = @CPF";

            var parametros = new
            {
                cpf
            };

            return await ExecuteFindAsync<PacienteDTO>(sql, null) != null;
        }

        #endregion Paciente
    }
}
