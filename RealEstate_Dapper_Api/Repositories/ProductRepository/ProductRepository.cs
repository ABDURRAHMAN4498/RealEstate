using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "select * from Product";
            using (var connection = _context.CreaConnection())
            {
                var values =await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "select ProductId,Title,Price,City,District,CategoryName, Type, CoverImage, Address, DealOfTheDay from Product inner join Category on Product.ProductCategory=Category.CategoryId;";
            using (var connection = _context.CreaConnection()){
                var values =await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync()
        {
            string query = "SELECT TOP (5) ProductId, Title,Price,City,District,ProductCategory,CategoryName,AdvertisementDate FROM Product Inner Join Category on Product.ProductCategory = Category.CategoryId where Type='Kiralik' Order by ProductId desc";
            using (var connection = _context.CreaConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertsListByEmployeeAsync(int id)
        {
            string query = $"select ProductId,Title,Price,City,District,CategoryName, Type, CoverImage, Address, DealOfTheDay from Product inner join Category on Product.ProductCategory=Category.CategoryId where EmplooyeId={id};";
            using (var connection = _context.CreaConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query);
                return values.ToList();
            }
        }

        public void ProductDealOfTheDayChangeToFalse(int id)
        {
            string query = $"Update Product set DealOfTheDay='False' Where ProductId = {id}";
            using(var connection = _context.CreaConnection()){
                connection.Execute(query);
            }
            
        }

        public void ProductDealOfTheDayChangeToTrue(int id)
        {
            string query = $"Update Product set DealOfTheDay='True' Where ProductId = {id}";
            using(var connection = _context.CreaConnection()){
                connection.Execute(query);
            }
        }
    }
}