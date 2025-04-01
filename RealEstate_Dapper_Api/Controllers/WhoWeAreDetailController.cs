using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDtos;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;
namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreDetailController : ControllerBase
    {
        private readonly IWhoWeAreRepository _whoWeAreRepository;

        public WhoWeAreDetailController(IWhoWeAreRepository whoWeAreRepository)
        {
            _whoWeAreRepository = whoWeAreRepository;
        }
        [HttpGet]
        public async Task<IActionResult> WhoWeAreDetailList()
        {
            var values = await _whoWeAreRepository.GatAllWhoWeAreDetailAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAreDetail(CreateWhoWeAreDetailDto whoWeAreDetailDto)
        {
            await _whoWeAreRepository.CreateWhoWeAreDetail(whoWeAreDetailDto);
            return Ok("seccessfuly");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
        {
            await _whoWeAreRepository.DeleteWhoWeAreDetail(id);
            return Ok("Deleting successful");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            await _whoWeAreRepository.UpdateWhoWeAreDetail(updateWhoWeAreDetailDto);
            return Ok("Updating is successful");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWhoWeAreDetail(int id)
        {
            var value = await _whoWeAreRepository.GetWhoWeAreDetail(id);
            return Ok(value);
        }
    }
}
