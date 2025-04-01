using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Dtos.TesimonialDtos;
using Microsoft.Extensions.Options;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.ViewComponents.HomePgae
{
    public class _DefaultOurTesimonialComponentPatial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        public _DefaultOurTesimonialComponentPatial(IHttpClientFactory httpClientFactory,IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "Tesimonials");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultTesimonialDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
