using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly Context _context;

        public BottomGridRepository(Context context)
        {
            _context = context;
        }

        public void CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
            string query = $"insert into BottomGrid (Icon,Title,Description) values ('{createBottomGridDto.Icon}','{createBottomGridDto.Title}','{createBottomGridDto.Description}');";
            using (var connection = _context.CreaConnection())
            {
                connection.Execute(query);
            }
        }

        public void DeleteBottomGrid(int id)
        {
            string query = $"delete from BottomGrid where BottomGridId={id}";
            using (var connection = _context.CreaConnection())
            {
                connection.Execute(query);
            }
        }

        public async Task<List<ResultBottomGridDto>> GatAllBottomGridAsync()
        {
            string query = "select * from BottomGrid";
            using (var connction = _context.CreaConnection())
            {
                var values = await connction.QueryAsync<ResultBottomGridDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdBottomGridDto> GetByIdBottomGrid(int id)
        {
            string query = $"select * from BottomGrid where BottomGridId = {id}";
            using(var connection = _context.CreaConnection()){
                var value = await connection.QuerySingleOrDefaultAsync<GetByIdBottomGridDto>(query);
                return value;
            }
        }

        public void UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
        {
            string query = $"Update BottomGrid set Icon='{updateBottomGridDto.Icon}',Title='{updateBottomGridDto.Title}',Description='{updateBottomGridDto.Description}'  where BottomGridId={updateBottomGridDto.BottomGridId}";
            using(var connection = _context.CreaConnection()){
                connection.Execute(query);
            }
        }
    }
}