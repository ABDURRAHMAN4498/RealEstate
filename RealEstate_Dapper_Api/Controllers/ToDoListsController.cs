using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ToDoListRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        private readonly IToDoListRepository _toDoListRepository;

        public ToDoListsController(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }
        [HttpGet("ToDoListList")]
        public async Task<IActionResult> ToDoListList()
        {
            var values = await _toDoListRepository.GatAllToDoListAsync();
            return Ok(values);
        }
    }
}
