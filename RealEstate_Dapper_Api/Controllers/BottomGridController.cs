using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Repositories.BottomGridRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BottomGridsController : ControllerBase
    {
        private readonly IBottomGridRepository _bottomGridRepository;

        public BottomGridsController(IBottomGridRepository bottomGridRepository)
        {
            _bottomGridRepository = bottomGridRepository;
        }
        [HttpGet]
        public async Task<IActionResult> BottomGridList()
        {
            var values = await _bottomGridRepository.GatAllBottomGridAsync();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
            _bottomGridRepository.CreateBottomGrid(createBottomGridDto);
            return Ok("seccessfuly");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBottomGrid(int id){
            _bottomGridRepository.DeleteBottomGrid(id);
            return Ok("Deleting is successfull");
        }
        [HttpPut]
        public IActionResult UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto){
            _bottomGridRepository.UpdateBottomGrid(updateBottomGridDto);
            return Ok("updating is successfull");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdBottomGrid(int id){
            var value = await _bottomGridRepository.GetByIdBottomGrid(id);
            return Ok(value);
        }
    }
}