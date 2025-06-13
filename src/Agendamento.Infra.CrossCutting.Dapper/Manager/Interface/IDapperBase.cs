using Microsoft.Data.SqlClient;

namespace Agendamento.Infra.CrossCutting.Dapper.Manager.Interface
{
    public interface IDapperBase
    {
        Task<IEnumerable<TEntity>> ExecuteQueryAsync<TEntity>(string query, object parametro, SqlConnection dbConnect = null);
        Task<TEntity> ExecuteFindAsync<TEntity>(string query, object parametro, SqlConnection dbConnect = null);
        Task ExecuteCreateAsync(string sql, object parametros, SqlConnection dbConnect = null);
    }
}
