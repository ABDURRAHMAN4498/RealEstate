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
        /*[ProductId]
      ,[Title]
      ,[Price]
      ,[CoverImage]
      ,[City]
      ,[District]
      ,[Address]
      ,[Description]
      ,[ProductCategory]
      ,[EmplooyeId]
      ,[Type]
      ,[DealOfTheDay]
      ,[AdvertisementDate]
      ,[ProductStatus]*/
        public async Task CreateProduct(CreateProductDto createProductDto)
        {

            string query = "insert into Product  values(@Title,@Price,@CoverImage,@City,@District,@Address,@Description,@ProductCategory,@EmplooyeId,@Type,@DealOfTheDay,@AdvertisementDate,@ProductStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", createProductDto.Title);
            parameters.Add("@Price", createProductDto.Price);
            parameters.Add("@CoverImage", createProductDto.CoverImage);
            parameters.Add("@City", createProductDto.City);
            parameters.Add("@District", createProductDto.District);
            parameters.Add("@Address", createProductDto.Address);
            parameters.Add("@Description", createProductDto.Description);
            parameters.Add("@ProductCategory", createProductDto.ProductCategory);
            parameters.Add("@EmplooyeId", createProductDto.EmplooyeId);
            parameters.Add("@Type", createProductDto.Type);
            parameters.Add("@DealOfTheDay", createProductDto.DealOfTheDay);
            parameters.Add("@AdvertisementDate", createProductDto.AdvertisementDate);
            parameters.Add("@ProductStatus", createProductDto.ProductStatus);
            

            using (var connection = _context.CreaConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
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

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertsListByEmployeeAsyncByFalse(int id)
        {
            string query = $"Select ProductId,Title,Price,City,District,CategoryName, Type, CoverImage, Address, DealOfTheDay from Product inner join Category on Product.ProductCategory=Category.CategoryId where EmplooyeId={id} and Product.ProductStatus=0;";
            using (var connection = _context.CreaConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertsListByEmployeeAsyncByTrue(int id)
        {
            string query = $"select ProductId,Title,Price,City,District,CategoryName, Type, CoverImage, Address, DealOfTheDay from Product inner join Category on Product.ProductCategory=Category.CategoryId where EmplooyeId={id} and Product.ProductStatus=1;";
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