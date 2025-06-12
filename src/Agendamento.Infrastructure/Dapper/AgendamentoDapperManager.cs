using Agendamento.Domain.Core.DTO;
using Agendamento.Domain.Core.Types;
using Agendamento.Domain.Entities;
using Agendamento.Infra.CrossCutting.Dapper;
using Agendamento.Infrastructure.Context;
using Agendamento.Infrastructure.Dapper.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Collections;
using System.Data.Common;

namespace Agendamento.Infrastructure.Dapper
{
    public class AgendamentoDapperManager : DapperBase, IAgendamentoDapperManager
    {
        public AgendamentoDapperManager(IOptions<ApplicationSettings> options)
           : base(AgendamentoContext.GetConnectionStringFromEnvironment(),
                  options)
        {
        }

        public async Task<bool> TestarConnectionsAsync()
        {
            return await TestConnectionAsync();
        }

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
            INSERT INTO Consulta (Id, MedicoId, PacienteId, Data, Especialidade)
            VALUES (@Id, @MedicoId, @PacienteId, @Data, @Especialidade);";

            var parametros = new
            {
                Id = Guid.NewGuid(),
                consulta.MedicoId,
                consulta.PacienteId,
                consulta.Data,
                consulta.Especialidade
            };

            await ExecuteCreateAsync(sql, parametros);
        }

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
    }
}
