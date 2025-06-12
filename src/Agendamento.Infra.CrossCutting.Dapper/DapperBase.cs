using Agendamento.Domain.Core.Types;
using Agendamento.Infra.CrossCutting.Dapper.Manager.Interface;
using Dapper;
using Microsoft.Extensions.Options;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Agendamento.Infra.CrossCutting.Dapper
{
    public class DapperBase : IDapperBase
    {
        public readonly SqlConnection dbConnectPrimaria;
        private readonly int commandTimeOut;

        public DapperBase(string connectionStringPrimaria, IOptions<ApplicationSettings> options)
        {
            dbConnectPrimaria = new SqlConnection(connectionStringPrimaria);

            commandTimeOut = int.Parse(options.Value.DbCommandTimeout);
        }

        public async Task<IEnumerable<TEntity>> ExecuteQueryAsync<TEntity>(string query, object parametro, SqlConnection dbConnect = null)
        {
            if (dbConnect == null)
                dbConnect = dbConnectPrimaria;

            return await dbConnect.QueryAsync<TEntity>(query, parametro, commandTimeout: this.commandTimeOut);
        }

        public async Task ExecuteCreateAsync(string sql, object parametros, SqlConnection dbConnect = null)
        {
            if (dbConnect == null)
                dbConnect = dbConnectPrimaria;

            await dbConnect.ExecuteAsync(sql, parametros);
        }

        public async Task<bool> TestConnectionAsync()
        {
            try
            {
                var connection = dbConnectPrimaria;
                await connection.OpenAsync();

                var result = await connection.ExecuteScalarAsync<int>("SELECT 1");

                return result == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao testar conexão: {ex.Message}");
                return false;
            }
        }
    }
}

