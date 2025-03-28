using Dapper;
using RealEstate_Dapper_Api.Dtos.SubFreatureDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.SubFreatureRepositories
{
    public class SubFreatureRepository : ISubFreatureRepository
    {
        private readonly Context _context;

        public SubFreatureRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultSubFreatureDto>> GetAllSubFreatureAsync()
        {
            string query = "SELECT SubFeatureId, Icon, TopTitle, MainTitle, Description, SubTitle FROM SubFeature; ";
            using (var connection = _context.CreaConnection())
            {
                var values = await connection.QueryAsync<ResultSubFreatureDto>(query);
                return values.ToList();
            }
        }
    }
}