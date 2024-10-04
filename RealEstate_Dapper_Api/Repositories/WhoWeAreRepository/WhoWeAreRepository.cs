using Dapper;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public class WhoWeAreRepository : IWhoWeAreRepository
    {
        private readonly Context _context;

        public WhoWeAreRepository(Context context)
        {
            _context = context;
        }

        public async void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            string query = $"insert into WhoWeAreDetail (Title,SubTitle,Description1,Description2) " +
                $"values(" +
                $"'{createWhoWeAreDetailDto.Title}'," +
                $"'{createWhoWeAreDetailDto.SubTitle}'," +
                $"'{createWhoWeAreDetailDto.Description1}'," +
                $"'{createWhoWeAreDetailDto.Description2}')";
            using (var connection = _context.CreaConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }

        public async void DeleteWhoWeAreDetail(int id)
        {
            string query = $"delete from WhoWeAreDetail where WhoWeAreDetailId={id}";
            using (var connection = _context.CreaConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GatAllWhoWeAreDetailAsync()
        {
            string query = "select * from WhoWeAreDetail;";
            using (var connection = _context.CreaConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
                return values.ToList(); 
            }
        }

        public async Task<GetByIdWhoWeAreDetailDto> GetWhoWeAreDetail(int id)
        {
            string query = $"select * from WhoWeAreDetail where WhoWeAreDetailId={id};";
            using (var connection = _context.CreaConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdWhoWeAreDetailDto>(query);
                return values;
            }
        }

        public void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            string query = $"update WhoWeAreDetail set " +
                $"Title='{updateWhoWeAreDetailDto.Title}'," +
                $"SubTitle='{updateWhoWeAreDetailDto.SubTitle}'," +
                $"Description1='{updateWhoWeAreDetailDto.Description1}'," +
                $"Description2='{updateWhoWeAreDetailDto.Description2}'" +
                $"where WhoWeAreDetailId={updateWhoWeAreDetailDto.WhoWeAreDetailId};";
            using (var connection = _context.CreaConnection())
            {
                var values = connection.Execute(query);
               
            }
        }
    }
}
