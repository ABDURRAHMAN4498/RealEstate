using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async void CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            string query = $"insert into Employee " +
            "(Name,Title,Mail,PhoneNumber,ImageUrl,Status) " +
            "values " +
            $"('{createEmployeeDto.Name}','{createEmployeeDto.Title}','{createEmployeeDto.Mail}','{createEmployeeDto.PhoneNumber}','{createEmployeeDto.ImageUrl}','{createEmployeeDto.Status}');";
            using (var connection = _context.CreaConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }

        public async void DeleteEmployee(int id)
        {
            string query = $"Delete From Employee Where EmployeeId={id};";
            using (var connection = _context.CreaConnection())
            {
                await connection.ExecuteAsync(query);
            }

        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
        {
            string query = "select * from Employee;";
            using (var connection = _context.CreaConnection())
            {
                var vaules = await connection.QueryAsync<ResultEmployeeDto>(query);
                return vaules.ToList();
            }
        }

        public async Task<GetByIdEmployeeDto> GetEmployee(int id)
        {
            string query = $"select * from Employee where EmployeeId = {id}";
            using (var connection = _context.CreaConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdEmployeeDto>(query);
                return value;
            }
        }

        public async void UpdateEmployeeDto(UpdateEmployeeDto updateEmployeeDto)
        {
            string query = $"Update Employee Set Name ='{updateEmployeeDto.Name}',Title='{updateEmployeeDto.Title}', Mail='{updateEmployeeDto.Mail}',PhoneNumber='{updateEmployeeDto.PhoneNumber}',ImageUrl='{updateEmployeeDto.ImageUrl}',Status='{updateEmployeeDto.Status}' Where EmployeeId={updateEmployeeDto.EmployeeId}";
            using (var connection = _context.CreaConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }
    }
}