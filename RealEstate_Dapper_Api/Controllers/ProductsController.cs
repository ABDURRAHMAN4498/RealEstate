using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productRepository.GetAllCategoryAsync();
            return Ok(values);
        }
        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productRepository.GetAllProductWithCategoryAsync();
            return Ok(values);
        }
        [HttpGet("ProductDealOfTheDayChangeToTrue/{id}")]
        public IActionResult ProductDealOfTheDayChangeToTrue(int id){
            _productRepository.ProductDealOfTheDayChangeToTrue(id);
            return Ok("İlan dürümü Güncellendi");
        }
        [HttpGet("ProductDealOfTheDayChangeToFalse/{id}")]
        public IActionResult ProductDealOfTheDayChangeToFalse(int id){
            _productRepository.ProductDealOfTheDayChangeToFalse(id);
            return Ok("İlan dürümü Güncellendi");
        }
    }
}
