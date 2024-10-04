using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.StatisticRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticRepository _statisticRepository;

        public StatisticController(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }
        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCateg1oryCount()
        {
            return Ok(_statisticRepository.ActiveCategoryCount());
        }
        [HttpGet("ActiveEmployeeCount")]
        public IActionResult ActiveEmployeeCount()
        {
            return Ok(_statisticRepository.ActiveEmployeeCount());
        }
        [HttpGet("ApartmentCount")]
        public IActionResult ApartmentCount()
        {
            return Ok(_statisticRepository.ApartmentCount());
        }
        [HttpGet("AvarageProductPriceByRent")]
        public IActionResult AvarageProductPriceByRent()
        {
            return Ok(_statisticRepository.AvarageProductPriceByRent());
        }
        [HttpGet("AvarageProductPriceBySale")]
        public IActionResult AvarageProductPriceBySale()
        {
            return Ok(_statisticRepository.AvarageProductPriceBySale());
        }
        [HttpGet("AvarageRoomCount")]
        public IActionResult AvarageRoomCount()
        {
            return Ok(_statisticRepository.AvarageRoomCount());
        }
        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            return Ok(_statisticRepository.CategoryCount());
        }

        [HttpGet("CategoryNameByMaxProductCount")]
        public IActionResult CategoryNameByMaxProductCount()
        {
            return Ok(_statisticRepository.CategoryNameByMaxProductCount());
        }


        [HttpGet("CityNameByMaxProductCount")]
        public IActionResult CityNameByMaxProductCount()
        {
            return Ok(_statisticRepository.CityNameByMaxProductCount());
        }
        [HttpGet("DifferentCityCount")]
        public IActionResult DifferentCityCount()
        {
            return Ok(_statisticRepository.DifferentCityCount());
        }

        [HttpGet("EmployeeNameByMaxProductCount")]
        public IActionResult EmployeeNameByMaxProductCount()
        {
            return Ok(_statisticRepository.EmployeeNameByMaxProductCount());
        }

        [HttpGet("LastProductPrice")]
        public IActionResult LastProductPrice()
        {
            return Ok(_statisticRepository.LastProductPrice());
        }

        [HttpGet("NewestbuildingYear")]
        public IActionResult NewestbuildingYear()
        {
            return Ok(_statisticRepository.NewestbuildingYear());
        }
        [HttpGet("OldestbuildingYear")]
        public IActionResult OldestbuildingYear()
        {
            return Ok(_statisticRepository.OldestbuildingYear());
        }


        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            return Ok(_statisticRepository.PassiveCategoryCount());
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_statisticRepository.ProductCount());
        }

        
    }
}