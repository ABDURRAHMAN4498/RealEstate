using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.PopularLocationDtos;
using RealEstate_Dapper_UI.StaticValues;
using System.Security.Cryptography.X509Certificates;

namespace RealEstate_Dapper_UI.ViewComponents.HomePgae
{
    public class _DefaultProductListExploreCitiesComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultProductListExploreCitiesComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var client = _httpClientFactory.CreateClient();
            var responserMassage = await client.GetAsync(PublicValues.Url+"PopularLocations");
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
