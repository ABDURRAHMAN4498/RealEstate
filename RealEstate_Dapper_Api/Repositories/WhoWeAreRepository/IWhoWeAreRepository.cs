using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDtos;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public interface IWhoWeAreRepository
    {
        public Task<List<ResultWhoWeAreDetailDto>> GatAllWhoWeAreDetailAsync();
        Task CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto);
        Task DeleteWhoWeAreDetail(int id);
        Task UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto);
        Task<GetByIdWhoWeAreDetailDto> GetWhoWeAreDetail(int id);
    }
}