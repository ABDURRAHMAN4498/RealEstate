using RealEstate_Dapper_Api.Dtos.AppUser;

namespace RealEstate_Dapper_Api.Repositories.AppUserRepositories;

public interface IAppUserRepository
{
    Task<GetAppUserByProductId>  GetAppUserByProductId(int id);
}