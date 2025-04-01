using RealEstate_Dapper_Api.Dtos;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        public Task<List<ResultCategoryDto>> GatAllCategoryAsync();
        Task CreateCategory(CreateCategoryDto categoryDto);
        Task DeleteCategory(int id);
        Task UpdateCategory(UpdateCategoryDto categoryDto);
        Task<GetByIdCategoryDto> GetCategory(int id);
    }
}
