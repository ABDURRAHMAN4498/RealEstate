using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.PopularLocationDtos;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.ViewComponents.HomePgae
{
    public class _DefaultProductListExploreCitiesComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public _DefaultProductListExploreCitiesComponentPartial(IHttpClientFactory httpClientFactory,
            IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responserMassage = await client.GetAsync(_apiSettings.BaseUrl + "PopularLocations");
            if (responserMassage.IsSuccessStatusCode)
            {
                var jsonData = await responserMassage.Content.ReadAsStringAsync();
                var vaules = JsonConvert.DeserializeObject<List<ResultPopularLocationDto>>(jsonData);
                return View(vaules);
            }

            return View();
        }
    }
}