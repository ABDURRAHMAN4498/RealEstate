using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using RealEstate_Dapper_UI.StaticValues;
using RealEstate_Dapper_UI.ViewModels;

namespace RealEstate_Dapper_UI.ViewComponents.HomePgae
{
    public class _DefaultFeatureComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultFeatureComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //Products/GetCitiesList
            SearchListVM model = new SearchListVM();
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(PublicValues.Url + "Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                model.Categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            }
            var citiesResponseMessage = await client.GetAsync(PublicValues.Url + "Products/GetCitiesList");
            if (citiesResponseMessage.IsSuccessStatusCode)
            {
                var citiesJsonData = await citiesResponseMessage.Content.ReadAsStringAsync();
                model.Cities = JsonConvert.DeserializeObject<List<string>>(citiesJsonData);
            }
            return View(model);
        }
    }
}