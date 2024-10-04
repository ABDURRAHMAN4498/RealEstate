using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Dtos.TesimonialDtos;
using RealEstate_Dapper_UI.StaticValues;
using System.Net.Http;

namespace RealEstate_Dapper_UI.ViewComponents.HomePgae
{
    public class _DefaultOurTesimonialComponentPatial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOurTesimonialComponentPatial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(PublicValues.Url + "Tesimonials");
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
