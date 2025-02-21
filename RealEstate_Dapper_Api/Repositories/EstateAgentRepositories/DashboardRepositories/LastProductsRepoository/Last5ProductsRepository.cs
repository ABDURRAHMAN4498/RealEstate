using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepoository
{
    public class Last5ProductsRepository : ILast5ProductsRepository
    {
        private readonly Context _context;

        public Last5ProductsRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync(int id)
        {
            string query = $"SELECT TOP (5) ProductId, Title,Price,City,District,ProductCategory,CategoryName,AdvertisementDate FROM Product Inner Join Category on Product.ProductCategory = Category.CategoryId where EmplooyeId={id} Order by ProductId desc";
            
            using (var connection = _context.CreaConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }
    }
}
