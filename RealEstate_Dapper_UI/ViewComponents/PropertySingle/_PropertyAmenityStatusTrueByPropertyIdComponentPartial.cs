using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.StaticValues;
using System.Security.Cryptography.X509Certificates;

namespace RealEstate_Dapper_UI.ViewComponents.PropertySingle
{
    public class _PropertyAmenityStatusTrueByPropertyIdComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _PropertyAmenityStatusTrueByPropertyIdComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(PublicValues.Url + "PropertyAmenities/GetAllPropertyAmenityByStatusTrue?id=2");

            return View();
        }
    }
}
