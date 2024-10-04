using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationsController : ControllerBase
    {
        private readonly IPopularLocationRepository _popularLocationRepository;
        public PopularLocationsController(IPopularLocationRepository popularLocationRepository)
        {
            _popularLocationRepository = popularLocationRepository;
        }
        [HttpGet]
        public async Task<IActionResult> PopularLocationList()
        {
            var values = await _popularLocationRepository.GatAllPopularLocationAsync();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto){
            _popularLocationRepository.CreatePopularLocation(createPopularLocationDto);
            return Ok("Lokasyon başarlı bir şekilde oluştu");
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePopularLocation(int id){
            _popularLocationRepository.DeletePopularLocation(id);
            return Ok("Lokasyon başarlı bir şekilde oluşturuldu");
        }
        [HttpPut] 
        public IActionResult UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto){
            _popularLocationRepository.UpdatePopularLocation(updatePopularLocationDto);
            return Ok("Lokasyon başarlı bir şekilde Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdPopularLocation(int id){
            var value =await _popularLocationRepository.GetPopularLocation(id);
            return Ok(value);
        }
    }

}