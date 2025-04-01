using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.SubFreatureDtos;
using RealEstate_Dapper_UI.Models;
namespace RealEstate_Dapper_UI.ViewComponents.HomePgae
{
    public class _DefaultSubFeatureComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        public _DefaultSubFeatureComponentPartial(IHttpClientFactory httpClientFactory,IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.GetAsync(_apiSettings.BaseUrl +"SubFreature/GetSubFeatureList");
            if (reponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await reponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSubFreatureDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
