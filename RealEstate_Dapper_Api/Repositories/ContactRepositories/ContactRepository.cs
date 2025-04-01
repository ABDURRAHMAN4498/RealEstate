using Dapper;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateContact(CreateContactDto createContactDto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteContact(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            string query = "select * from Contact;";
            using (var connection = _context.CreaConnection())
            {
                var vaules = await connection.QueryAsync<ResultContactDto>(query);
                return vaules.ToList();
            }
        }

        public async Task<GetByIDContactDto> GetContact(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Last4ContactResultDto>> GetLast4Contact()
        {
            string query = "SELECT TOP (4) * FROM Contact order by ContactId desc";
            using (var connection = _context.CreaConnection())
            {
                var vaules = await connection.QueryAsync<Last4ContactResultDto>(query);
                return vaules.ToList();
            }
        }
    }
}
