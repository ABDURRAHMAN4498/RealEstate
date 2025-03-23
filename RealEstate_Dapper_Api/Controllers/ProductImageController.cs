using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductImageRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageRepository _productImageRepository;

        public ProductImageController(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }
        [HttpGet("GetProductImageById")]
        public async Task<IActionResult> GetProductImageById(int id){
            var value = await _productImageRepository.GetProductImageByProductId(id);
            return Ok(value);
        }
    }
}