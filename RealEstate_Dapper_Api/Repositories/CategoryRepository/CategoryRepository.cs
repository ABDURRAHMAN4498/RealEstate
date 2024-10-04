using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using Dapper;
using System.Windows.Markup;
using RealEstate_Dapper_Api.Dtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;
        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "insert into Category (CategoryName,CategoryStatus) values(@categoryName,@categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);

            using (var connection = _context.CreaConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteCategory(int id)
        {
            string query = $"Delete From Category Where CategoryId={id}";
            using (var connection = _context.CreaConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }

        public async Task<List<ResultCategoryDto>> GatAllCategoryAsync()
        {
            string query = "Select * From Category";
            using (var connection = _context.CreaConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCategoryDto> GetCategory(int id)
        {
            string query = $"select * from Category where CategoryId={id};";
            using (var connection = _context.CreaConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query);
                return value;
            }
        }

        public async void UpdateCategory(UpdateCategoryDto categoryDto)
        {
            string query = $"Update Category Set CategoryName='{categoryDto.CategoryName}',CategoryStatus='{categoryDto.CategoryStatus}' where CategoryId={categoryDto.CategoryId};";
            using (var connection = _context.CreaConnection())
            {
                await connection.ExecuteAsync(query);

            }
        }
    }
}
