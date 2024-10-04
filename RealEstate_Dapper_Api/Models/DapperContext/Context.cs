using System.Data;
using Microsoft.Data.SqlClient;

namespace RealEstate_Dapper_Api.Models.DapperContext
{
    public class Context
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("connection")!.Replace("localhost","94.154.37.220").Replace("myDataBase","DbDapperRealEstat").Replace("myUser","vipqr").Replace("***************","Abd441453");
        }
        public IDbConnection CreaConnection() => new SqlConnection(_connectionString);
    }
}
