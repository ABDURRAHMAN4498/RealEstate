using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.EstateAgentDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Services;
using RealEstate_Dapper_UI.StaticValues;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentLast5ProductComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _EstateAgentLast5ProductComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var responsemassage = await client.GetAsync(PublicValues.Url + $"EstateAgentLastProducts/GetLast5ProductAsync?id={id}");
            if (responsemassage.IsSuccessStatusCode)
            {
                var jsonData = await responsemassage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast5ProductWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}