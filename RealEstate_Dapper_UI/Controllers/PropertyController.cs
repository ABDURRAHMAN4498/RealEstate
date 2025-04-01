using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.AppUser;
using RealEstate_Dapper_UI.Dtos.ProductDetailDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Dtos.ProductImageDto;
using RealEstate_Dapper_UI.Dtos.PropertyAmenityDtos;
using RealEstate_Dapper_UI.Models;
using RealEstate_Dapper_UI.ViewModels;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        public PropertyController(IHttpClientFactory httpClientFactory,IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "Products/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDto>>(jsonData);
                return View(value);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PropertyListWithSearch(string searchKeyValue, int propertyCategoryId,
            string City)
        {
            
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_apiSettings.BaseUrl +
                                                        $"Products/ResultProductWithSearchList?searchKeyValue={searchKeyValue}&propertyCategoryId={propertyCategoryId}&City={City}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDto>>(jsonData);
                return View(value);
            }

            return View();
        }

        [HttpGet("property/{slug}/{id}")]
        public async Task<IActionResult> PropertySingle(string slug,int id)
        {
            SinglePropertyVM model = new SinglePropertyVM();
            
            //product
            var client = _httpClientFactory.CreateClient();
            var productResponseMessage =
                await client.GetAsync(_apiSettings.BaseUrl + "Products/GetProductByProductId?id=" + id);
            var productJsonData = await productResponseMessage.Content.ReadAsStringAsync();
            model.Product = JsonConvert.DeserializeObject<ResultProductDto>(productJsonData);
            //product detail 
            TimeSpan timeSpan = DateTime.Now - model.Product.advertisementDate;
            int totalDays = timeSpan.Days;
            model.Month = totalDays / 30;
            model.Day = totalDays % 30;
            var productDetailResponseMessage =
                await client.GetAsync(_apiSettings.BaseUrl + "ProductDetails/GetProductDetailByProductId?id=" + id);
            var productDetailJsonData = await productDetailResponseMessage.Content.ReadAsStringAsync();
            model.ProductDetail = JsonConvert.DeserializeObject<GetProductDetailByIdDto>(productDetailJsonData);
            //Product Images
            var productImageResponseMessage =
                await client.GetAsync(_apiSettings.BaseUrl + "ProductImage/GetProductImageById?id=" + id);
            var productImageJsonData = await productImageResponseMessage.Content.ReadAsStringAsync();
            model.ProductImage = JsonConvert.DeserializeObject<List<GetProductImageDto>>(productImageJsonData);
            if (model.ProductImage.Count()==0)
            {
                model.ProductImage.Add(new GetProductImageDto()
                {
                    imageUrl = "~/starter/images/noImage.jpeg",
                });
            }
            //App User Info.
            var appUserResponseMessage =
                await client.GetAsync(_apiSettings.BaseUrl + "AppUser/GetAppUserByProductId?id=" + model.Product.AppUserId);
            var appUserJsonData = await appUserResponseMessage.Content.ReadAsStringAsync();
            model.AppUser = JsonConvert.DeserializeObject<GetAppUserByProductId>(appUserJsonData);

            //PropertyAmenity
            var propertyAmenityResponseMessage =
                await client.GetAsync(_apiSettings.BaseUrl + "PropertyAmenities/GetAllPropertyAmenityByStatusTrue?id=" +
                                      id);
            var propertyAmenityJsonData = await propertyAmenityResponseMessage.Content.ReadAsStringAsync();
            model.PropertyAmenity =
                JsonConvert.DeserializeObject<List<ResultPropertyAmenityByStatusTrueDto>>(propertyAmenityJsonData);
             model.SlugUrl = CreateSlug(model.Product.title);
            return View(model);
        }
        private string CreateSlug(string title)
        {
            title = title.ToLowerInvariant(); // Küçük harfe çevir
            title = title.Replace(" ", "-"); // Boşlukları tire ile değiştir
            title = System.Text.RegularExpressions.Regex.Replace(title, @"[^a-z0-9\s-]", ""); // Geçersiz karakterleri kaldır
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s+", " ").Trim(); // Birden fazla boşluğu tek boşluğa indir ve kenar boşluklarını kaldır
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s", "-"); // Boşlukları tire ile değiştir

            return title;
        }
    }
}