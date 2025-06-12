using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Data;

namespace Agendamento.Infrastructure.Context
{
    public class AgendamentoContext
    {

        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public AgendamentoContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection")!;
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);

        public static string GetConnectionStringFromEnvironment()
        {
            IDictionary _envVars = Environment.GetEnvironmentVariables();

            string _dataSource = _envVars["DB_DATA_SOURCE"].ToString();
            string _dataBase = _envVars["DB_CATALOG"].ToString();
            string _user = _envVars["DB_DATABASE_USER"].ToString();
            string _password = _envVars["DB_DATABASE_USER_PASSWORD"].ToString();

            SqlConnectionStringBuilder _connectionStringBuilder = new SqlConnectionStringBuilder();

            _connectionStringBuilder.DataSource = _dataSource;
            _connectionStringBuilder.InitialCatalog = _dataBase;
            _connectionStringBuilder.IntegratedSecurity = true;
            _connectionStringBuilder.PersistSecurityInfo = false;
            _connectionStringBuilder.UserID = _user;
            _connectionStringBuilder.Password = _password;
            _connectionStringBuilder.MultipleActiveResultSets = false;
            _connectionStringBuilder.Encrypt = false;
            _connectionStringBuilder.TrustServerCertificate = false;
            _connectionStringBuilder.Add(keyword: "Trusted_Connection", value: false);
            _connectionStringBuilder.Pooling = true;
            _connectionStringBuilder.MaxPoolSize = 5000;

            return _connectionStringBuilder.ConnectionString;
        }
    }
}