using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.StaticValues;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
        // GET
        private readonly IHttpClientFactory _httpClientFactory;

        public PropertyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index() 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage =await client.GetAsync(PublicValues.Url+"Products/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(value);
            }
            return View(); 
        }

        [HttpGet]
        public async Task<IActionResult> PropertySingle(int id)
        {
            return View();
        } 
    }    
}

