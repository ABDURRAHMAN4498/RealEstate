using Dapper;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;


namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepository
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async Task CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            string query = $"insert into PopularLocation (CityName,ImageUrl) values ('{createPopularLocationDto.CityName}','{createPopularLocationDto.ImageUrl}')";
            using(var connection = _context.CreaConnection()){
                await connection.ExecuteAsync(query);
            }
        }
        public async Task DeletePopularLocation(int id)
        {
            string query = $"delete from PopularLocation where LocationId = {id}";
            using(var connection = _context.CreaConnection()){
                await connection.ExecuteAsync(query);
            }
        }
        public async Task<List<ResultPopularLocationDto>> GatAllPopularLocationAsync()
        {
            string query = "select * from PopularLocation";
            using (var connection = _context.CreaConnection()){
                var values = await connection.QueryAsync<ResultPopularLocationDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdPopularLocationDto> GetPopularLocation(int id)
        {
            string query = $"select * from PopularLocation where LocationId={id}";
            using(var connection = _context.CreaConnection()){
                var value = await connection.QuerySingleOrDefaultAsync<GetByIdPopularLocationDto>(query);
                return value;
            }
        }

        public async Task UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            string query = $"update PopularLocation set CityName='{updatePopularLocationDto.CityName}',ImageUrl='{updatePopularLocationDto.ImageUrl}' where LocationId={updatePopularLocationDto.LocationId}";
            using(var connection = _context.CreaConnection()){
               await connection.ExecuteAsync(query);
            }
        }
    }
}