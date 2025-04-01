using System.Windows.Markup;
using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
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
            string query = "select ProductId,Title,Price,City,District,CategoryName, Type, CoverImage, Address, DealOfTheDay, SlugUrl from Product inner join Category on Product.ProductCategory=Category.CategoryId;";
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

        public async Task<GetProductByProductIdDto> GetProductByProductId(int id)
        {
            string query = $"select ProductId,Title,Price,City,District,CategoryName, Type, CoverImage, Address, DealOfTheDay,AdvertisementDate,Description, SlugUrl, AppUserId from Product inner join Category on Product.ProductCategory=Category.CategoryId WHERE ProductId = {id};";
            using (var connection = _context.CreaConnection()){
                var values =await connection.QueryFirstOrDefaultAsync<GetProductByProductIdDto>(query);
                return values;
            }
        }

        public async Task<GetProductDetailDto> GetProductDetailByProductId(int id)
        {
            string query = $"Select * from ProductDetails WHERE ProductId = {id};";
            using (var connection = _context.CreaConnection()){
                var values =await connection.QueryFirstOrDefaultAsync<GetProductDetailDto>(query);
                return values;
            }
        }

        public async Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryId, string City)
        {
            string query = $"SELECT * from Product where Title LIKE '%{searchKeyValue}%' and ProductCategory = {propertyCategoryId} and City LIKE '%{City}%'";
            using (var connection = _context.CreaConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithSearchListDto>(query);
                return values.ToList();
            }
        }

        public async Task ProductDealOfTheDayChangeToFalse(int id)
        {
            string query = $"Update Product set DealOfTheDay='False' Where ProductId = {id}";
            using(var connection = _context.CreaConnection()){
                await connection.ExecuteAsync(query);
            }
            
        }

        public async Task ProductDealOfTheDayChangeToTrue(int id)
        {
            string query = $"Update Product set DealOfTheDay='True' Where ProductId = {id}";
            using(var connection = _context.CreaConnection()){
                await connection.ExecuteAsync(query);
            }
        }

        public async Task<List<string>> GetCitiesList()
        {
            string query = "SELECT  City from Product GROUP  BY  City ORDER By City ";
            using(var connection = _context.CreaConnection()){
                var values = await connection.QueryAsync<string>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductByDealOfTheDayTrueWithCategoryAsync()
        {
            string query = "SELECT ProductId, Title, Price, City, District, CategoryName, CoverImage, Type, Address, DealOfTheDay from Product inner join Category  on ProductCategory  = CategoryId where DealOfTheDay = 1";
            using(var connection = _context.CreaConnection()){
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList(); 
            } 
        }

        public async Task<List<ResultLast3ProductWithCategoryDto>> GetLast3ProductAsync()
        {
            string query = "SELECT TOP (3) ProductId, CoverImage, Title,Price,City,District,ProductCategory,CategoryName,AdvertisementDate, Description FROM Product Inner Join Category on Product.ProductCategory = Category.CategoryId where Type='Kiralik' Order by ProductId desc";
            using(var connection = _context.CreaConnection()){
                var values = await connection.QueryAsync<ResultLast3ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }
    }
}