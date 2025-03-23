using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductImageDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductImageRepositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly Context _context;

        public ProductImageRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<GetProductImageByProductIdDto>> GetProductImageByProductId(int id)
        {
            string query = $"SELECT * FROM ProductImage where ProductId = {id}";
            using(var connection = _context.CreaConnection()){
                var values =await connection.QueryAsync<GetProductImageByProductIdDto>(query);
                return values.ToList();
            }
        }
    }
}