using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using RealEstate_Dapper_UI.Models;
using RealEstate_Dapper_UI.ViewModels;

namespace RealEstate_Dapper_UI.ViewComponents.HomePgae
{
    public class _DefaultFeatureComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        public _DefaultFeatureComponentPartial(IHttpClientFactory httpClientFactory,IOptions<ApiSettings>  apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //Products/GetCitiesList
            SearchListVM model = new SearchListVM();
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                model.Categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            }
            var citiesResponseMessage = await client.GetAsync(_apiSettings.BaseUrl + "Products/GetCitiesList");
            if (citiesResponseMessage.IsSuccessStatusCode)
            {
                var citiesJsonData = await citiesResponseMessage.Content.ReadAsStringAsync();
                model.Cities = JsonConvert.DeserializeObject<List<string>>(citiesJsonData);
            }
            return View(model);
        }
    }
}