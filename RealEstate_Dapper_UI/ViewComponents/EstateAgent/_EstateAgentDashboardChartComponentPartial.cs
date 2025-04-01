using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.EstateAgentDtos;
using RealEstate_Dapper_UI.Models;


namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardChartComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        public _EstateAgentDashboardChartComponentPartial(IHttpClientFactory httpClientFactory,IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemassage = await client.GetAsync(_apiSettings.BaseUrl + "EstateAgentChart/Get5CityForChart");
            if (responsemassage.IsSuccessStatusCode)
            {
                var jsonData = await responsemassage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEstateAgentDashboardChartDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}