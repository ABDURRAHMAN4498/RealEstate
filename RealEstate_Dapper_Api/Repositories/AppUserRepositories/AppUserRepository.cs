using Dapper;
using RealEstate_Dapper_Api.Dtos.AppUser;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.AppUserRepositories;

public class AppUserRepository : IAppUserRepository
{
    private readonly Context _context;

    public AppUserRepository(Context context)
    {
        _context = context;
    }

    public async Task<GetAppUserByProductId> GetAppUserByProductId(int id)
    {
        string query = $"SELECT * FROM AppUser where UserId = {id};";
        using ( var connection = _context.CreaConnection())
        {
            var value = await connection.QueryFirstOrDefaultAsync<GetAppUserByProductId>(query);
            return value;
        }
    }
}