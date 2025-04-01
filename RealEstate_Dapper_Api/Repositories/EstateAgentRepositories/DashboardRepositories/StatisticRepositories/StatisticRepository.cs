using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly Context _context;

        public StatisticRepository(Context context)
        {
            _context = context;
        }
        public int AllProductCount()
        {
            string query = "select count(*) from Product ";
            using (var connection = _context.CreaConnection())
            {
                var value = connection.QueryFirstOrDefault<int>(query);
                return value;
            }
        }
        

        public int ProductCountByEmployeeId(int id)
        {
            string query = $"select count(*) from Product where EmplooyeId={id};";
            using (var connection = _context.CreaConnection())
            {
                var value = connection.QueryFirstOrDefault<int>(query);
                return value;
        }
            }

        public int ProductCountByStatusFalse(int id)
        {
            string query = $"select count(*) from Product where AppUserId={id} and ProductStatus=0;";
            using (var connection = _context.CreaConnection())
            {
                var value = connection.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public int ProductCountByStatusTrue(int id)
        {
            string query = $"select count(*) from Product where EmplooyeId={id} and ProductStatus=1;";
            using (var connection = _context.CreaConnection())
            {
                var value = connection.QueryFirstOrDefault<int>(query);
                return value;
            }
        }
    }
}
