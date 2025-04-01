using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ServiceRepository;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServicesController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetServiceList()
        {
            var values = await _serviceRepository.GatAllServiceAsync();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateService(CreateServiceDto createServiceDto)
        {
            _serviceRepository.CreateService(createServiceDto);
            return Ok("seccessfuly");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            await _serviceRepository.DeleteService(id);
            return Ok("Deleting successful");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            await _serviceRepository.UpdateService(updateServiceDto);
            return Ok("Updating is successful");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var value =await _serviceRepository.GetService(id);
            return Ok(value);
        }
    }
}