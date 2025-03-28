using RealEstate_Dapper_Api.Dtos.SubFreatureDtos;

namespace RealEstate_Dapper_Api.Repositories.SubFreatureRepositories
{
    public interface ISubFreatureRepository
    {
        Task<List<ResultSubFreatureDto>> GetAllSubFreatureAsync();
    }
}