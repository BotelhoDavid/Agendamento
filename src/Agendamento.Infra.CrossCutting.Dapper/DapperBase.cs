using Agendamento.Domain.Core.Types;
using Agendamento.Infra.CrossCutting.Dapper.Manager.Interface;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

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

        public async Task<TEntity> ExecuteFindAsync<TEntity>(string query, object parametro, SqlConnection dbConnect = null)
        {
            if (dbConnect == null)
                dbConnect = dbConnectPrimaria;

            return await dbConnect.QueryFirstOrDefaultAsync<TEntity>(query, parametro, commandTimeout: this.commandTimeOut);
        }
    }
}

