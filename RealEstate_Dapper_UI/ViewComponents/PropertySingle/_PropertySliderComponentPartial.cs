using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductImageDto;
using System.Reflection;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.ViewComponents.PropertySingle
{
    public class _PropertySliderComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        public _PropertySliderComponentPartial(IHttpClientFactory httpClientFactory, ApiSettings apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var productImageResponseMessage = await client.GetAsync(_apiSettings.BaseUrl + "ProductImage/GetProductImageById?id=1");
            if (productImageResponseMessage.IsSuccessStatusCode)
            {
                var productImageJsonData = await productImageResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetProductImageDto>>(productImageJsonData);
                return View(values);
            }
            return View();
        }
    }
}
