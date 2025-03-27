using System.Windows.Markup;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
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
            var values = await _productRepository.GetAllProductAsync();
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
        [HttpGet("Last5ProductList")]
        public async Task<IActionResult> Last5ProductList()
        {
            var values = await _productRepository.GetLast5ProductAsync();
            return Ok(values);
        }
        [HttpGet("ProductAdvertsListByEmployeeByTrue")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeByTrue(int id)
        {
            var values = await _productRepository.GetProductAdvertsListByEmployeeAsyncByTrue(id);
            return Ok(values);
        }

        [HttpGet("ProductAdvertsListByEmployeeByFalse")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeFalse(int id)
        {
            var values = await _productRepository.GetProductAdvertsListByEmployeeAsyncByFalse(id);
            return Ok(values);
        }
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody]CreateProductDto createProductDto)
        {
            await _productRepository.CreateProduct(createProductDto);
            return Ok("İlan Başarı ile Eklendi");
        }
        [HttpGet("GetProductByProductId")]
        public async Task<IActionResult> GetProductByProductId(int id){
            var value =  await _productRepository.GetProductByProductId(id);
            return Ok(value);
        }

        [HttpGet("ResultProductWithSearchList")]
        public async Task<IActionResult> GetResultProductWithSearchList(string searchKeyValue, int propertyCategoryId, string City)
        {
            var values = await _productRepository.ResultProductWithSearchList(searchKeyValue, propertyCategoryId, City);
            return Ok(values);
        } 
        [HttpGet("GetCitiesList")]
        public async Task<IActionResult> GetCitiesList(){
            var values =await _productRepository.GetCitiesList();
            return Ok(values);

        }
        


    }
}
