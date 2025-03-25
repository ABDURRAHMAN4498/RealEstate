using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.AppUser;
using RealEstate_Dapper_UI.Dtos.ProductDetailDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Dtos.ProductImageDto;
using RealEstate_Dapper_UI.StaticValues;
using RealEstate_Dapper_UI.ViewModels;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
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
            SinglePropertyVM model = new SinglePropertyVM();
            id = 1;
            //product
            var client = _httpClientFactory.CreateClient();
            var productResponseMessage =await client.GetAsync(PublicValues.Url+"Products/GetProductByProductId?id=" + id);
            var productJsonData = await productResponseMessage.Content.ReadAsStringAsync(); 
            model.Product = JsonConvert.DeserializeObject<ResultProductDto>(productJsonData);
            //product detail 
            TimeSpan timeSpan = DateTime.Now - model.Product.advertisementDate;
            int totalDays = timeSpan.Days;
            model.Month=totalDays/30;
            model.Day=totalDays%30;
            var productDetailResponseMessage =await client.GetAsync(PublicValues.Url+"ProductDetails/GetProductDetailByProductId?id=" + id);
            var productDetailJsonData = await productDetailResponseMessage.Content.ReadAsStringAsync(); 
            model.ProductDetail = JsonConvert.DeserializeObject<GetProductDetailByIdDto>(productDetailJsonData);
            //Product Images
            var productImageResponseMessage = await client.GetAsync(PublicValues.Url+"ProductImage/GetProductImageById?id=" + id);
            var productImageJsonData = await productImageResponseMessage.Content.ReadAsStringAsync();
            model.ProductImage = JsonConvert.DeserializeObject<List<GetProductImageDto>>(productImageJsonData);
            //App User Info.
            var responseMessage = await client.GetAsync(PublicValues.Url + "AppUser/GetAppUserByProductId?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            model.AppUser = JsonConvert.DeserializeObject<GetAppUserByProductId>(jsonData);
            
            return View(model);
        } 
    }    
}

