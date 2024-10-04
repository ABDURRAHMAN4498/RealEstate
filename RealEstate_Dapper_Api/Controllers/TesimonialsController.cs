using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.TesimonialRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesimonialsController : ControllerBase
    {
        private readonly ITesimonialRepository _tesimonialRepository;

        public TesimonialsController(ITesimonialRepository tesimonialRepository)
        {
            _tesimonialRepository = tesimonialRepository;
        }

        [HttpGet]
        public async Task<IActionResult> TesimonialList(){
            var values =await _tesimonialRepository.GatAllTestimonialAsync();
            return Ok(values);
        }
    
    }
}