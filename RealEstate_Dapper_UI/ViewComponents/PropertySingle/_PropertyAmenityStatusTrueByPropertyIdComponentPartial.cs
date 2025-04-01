using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RealEstate_Dapper_UI.Models;


namespace RealEstate_Dapper_UI.ViewComponents.PropertySingle
{
    public class _PropertyAmenityStatusTrueByPropertyIdComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public _PropertyAmenityStatusTrueByPropertyIdComponentPartial(IHttpClientFactory httpClientFactory,IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "PropertyAmenities/GetAllPropertyAmenityByStatusTrue?id=2");

            return View();
        }
    }
}
