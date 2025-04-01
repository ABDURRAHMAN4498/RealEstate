using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.MessageDtos;
using RealEstate_Dapper_UI.Models;
using RealEstate_Dapper_UI.Services;


namespace RealEstate_Dapper_UI.Areas.EstateAgent.ViewComponents.EstateAgentNavbarViewCopmonents
{
    public class _NavbarLast3MessageComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly ApiSettings _apiSettings;
        public _NavbarLast3MessageComponentPartial(ILoginService loginService, IHttpClientFactory httpClientFactory,IOptions<ApiSettings> apiSettings)
        {
            _loginService = loginService;
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_apiSettings.BaseUrl+$"Messages?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultInBoxMessageDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}