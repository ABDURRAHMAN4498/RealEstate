using RealEstate_Dapper_Api.Dtos.ToDoListDtos;
namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDto>> GatAllToDoListAsync();
        Task CreateToDoList(CreateToDoListDto ToDoListDto);
        Task DeleteToDoList(int id);
        Task UpdateToDoList(UpdateToDoListDto ToDoListDto);
        Task<ResultToDoListDto> GetToDoList(int id);
    }
}
