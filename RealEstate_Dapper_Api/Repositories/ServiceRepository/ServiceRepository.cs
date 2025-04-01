using Dapper;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateService(CreateServiceDto createServiceDto)
        {
            string query = $"insert into Service (ServiceName,ServiceStatus) values ('{createServiceDto.ServiceName}','{createServiceDto.ServiceStatus}')";
            using (var connection = _context.CreaConnection())
            {
                 await connection.ExecuteAsync(query);
            }
        }

        public async Task DeleteService(int id)
        {
            string query = $"Delete From Service Where ServiceId={id}";
            using (var connection = _context.CreaConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }

        public async Task<List<ResultServiceDto>> GatAllServiceAsync()
        {
           string query = "select * from Service";
           using (var connection = _context.CreaConnection()){
                var values = await connection.QueryAsync<ResultServiceDto>(query);
                return values.ToList();
           }
        }

        public async Task<GetByIdServiceDto> GetService(int id)
        {
            string query = $"select * from Service where ServiceId = {id}";
            using (var connection = _context.CreaConnection()){
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdServiceDto>(query);
                return value;
            }
        }

        public async Task UpdateService(UpdateServiceDto updateServiceDto)
        {
            string query = $"Update Service Set ServiceName='{updateServiceDto.ServiceName}',ServiceStatus='{updateServiceDto.ServiceStatus}' where ServiceId={updateServiceDto.ServiceId};";
            using (var connection = _context.CreaConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }
    }
}