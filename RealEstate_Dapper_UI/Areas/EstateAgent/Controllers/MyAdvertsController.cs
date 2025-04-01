using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Models;
using RealEstate_Dapper_UI.Services;
namespace RealEstate_Dapper_UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    [Route("EstateAgent/[controller]")]
    public class MyAdvertsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly ApiSettings _apiSettings;
        public MyAdvertsController(IHttpClientFactory httpClientFactory, ILoginService loginService,IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IActionResult> ActiveAdverts()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemassage = await client.GetAsync(_apiSettings.BaseUrl + $"Products/ProductAdvertsListByEmployeeByTrue?id={_loginService.GetUserId}");
            if (responsemassage.IsSuccessStatusCode)
            {
                var jsonData = await responsemassage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductAdvertListWithCategoryByEmployeeDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> PassiveAdverts()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemassage = await client.GetAsync(_apiSettings.BaseUrl + $"Products/ProductAdvertsListByEmployeeByFalse?id={_loginService.GetUserId}");
            if (responsemassage.IsSuccessStatusCode)
            {
                var jsonData = await responsemassage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductAdvertListWithCategoryByEmployeeDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateAdvert()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "Categories");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> categoryValues = (from x in values.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString(),
                                                   }).ToList();
            ViewBag.Categories = categoryValues;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdvert([FromForm] CreateProductDto createProductDto)
        {
            createProductDto.DealOfTheDay = false;
            createProductDto.AdvertisementDate=DateTime.Now;
            createProductDto.ProductStatus=true;
            createProductDto.EmplooyeId = int.Parse(_loginService.GetUserId);
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync(_apiSettings.BaseUrl+"Products/CreateProduct",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ActiveAdverts");
            }
            return View(createProductDto);
        }
    }
}
