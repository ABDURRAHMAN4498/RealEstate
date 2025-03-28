using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.SubFreatureRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubFreatureController : ControllerBase
    {
        private readonly ISubFreatureRepository _subFreatureRepository;

        public SubFreatureController(ISubFreatureRepository subFreatureRepository)
        {
            _subFreatureRepository = subFreatureRepository;
        }
        [HttpGet("GetSubFeatureList")]
        public async Task<IActionResult> GetSubFeatureList()
        {
            return Ok(await _subFreatureRepository.GetAllSubFreatureAsync());
        }
    }
}