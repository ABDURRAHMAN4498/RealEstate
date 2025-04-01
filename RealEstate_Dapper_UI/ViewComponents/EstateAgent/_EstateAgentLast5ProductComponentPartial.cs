using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Models;
using RealEstate_Dapper_UI.Services;


namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentLast5ProductComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly ApiSettings _apiSettings;

        public _EstateAgentLast5ProductComponentPartial(IHttpClientFactory httpClientFactory,
            ILoginService loginService,IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var responsemassage =
                await client.GetAsync(_apiSettings.BaseUrl + $"EstateAgentLastProducts/GetLast5ProductAsync?id={id}");
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