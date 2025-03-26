using Dapper;
using RealEstate_Dapper_Api.Dtos.PropertyAmenityDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PropertyAmenityRepositories
{
    public class PropertyAmenityRepository : IPropertyAmenityRepository
    {
        private readonly Context _context;
        public PropertyAmenityRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultPropertyAmenityByStatusTrueDto>> GetAllPropertyAmenityByStatusTrue(int id)
        {
            string query = $"select PropertyAmenity.PropertyAmenityId ,Amentiy.Title from PropertyAmenity inner join Amentiy on Amentiy.AmenityId = PropertyAmenity.AmenityId where PropertyAmenity.PropertyId = {id} and PropertyAmenity.Status = 1";
            using (var connection = _context.CreaConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyAmenityByStatusTrueDto>(query);
                return values.ToList();
            }
        }
    }
}

