using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductImageDto;
using RealEstate_Dapper_UI.StaticValues;
using System.Reflection;

namespace RealEstate_Dapper_UI.ViewComponents.PropertySingle
{
    public class _PropertySliderComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _PropertySliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var productImageResponseMessage = await client.GetAsync(PublicValues.Url + "ProductImage/GetProductImageById?id=1");
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
