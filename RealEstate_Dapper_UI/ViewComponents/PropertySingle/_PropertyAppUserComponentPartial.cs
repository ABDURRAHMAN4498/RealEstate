using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.AppUser;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.ViewComponents.PropertySingle
{
    public class _PropertyAppUserComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        public _PropertyAppUserComponentPartial(IHttpClientFactory httpClientFactory,IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "AppUser/GetAppUserByProductId?id=1");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetAppUserByProductId>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
