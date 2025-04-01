using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using RealEstate_Dapper_UI.Models;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        public _DashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region ProductCount - Toplam ilan sayısı
            var clientProductCount = _httpClientFactory.CreateClient();
            var responseMessageProductCount = await clientProductCount.GetAsync(_apiSettings.BaseUrl + "Statistic/ProductCount");
            var jsonDataProductCount = await responseMessageProductCount.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonDataProductCount;
            #endregion

            #region EmployeeNameByMaxProductCount - En Başarlı Personel
            var clientEmployeeNameByMaxProductCount = _httpClientFactory.CreateClient();
            var responseMessageEmployeeNameByMaxProductCount = await clientEmployeeNameByMaxProductCount.GetAsync(_apiSettings.BaseUrl + "Statistic/EmployeeNameByMaxProductCount");
            var jsonDataEmployeeNameByMaxProductCount = await responseMessageEmployeeNameByMaxProductCount.Content.ReadAsStringAsync();
            ViewBag.EmployeeNameByMaxProductCount = jsonDataEmployeeNameByMaxProductCount;
            #endregion

            #region DifferentCityCount - ilandak şehir sayısı
            var clientDifferentCityCount = _httpClientFactory.CreateClient();
            var responseMessageDifferentCityCount = await clientDifferentCityCount.GetAsync(_apiSettings.BaseUrl + "Statistic/DifferentCityCount");
            var jsonDataDifferentCityCount = await responseMessageDifferentCityCount.Content.ReadAsStringAsync();
            ViewBag.DifferentCityCount = jsonDataDifferentCityCount;
            #endregion

            #region AvarageProductPriceByRent - Ortalama Kira Fiyatı
            var clientAvarageProductPriceByRent = _httpClientFactory.CreateClient();
            var responseMessageAvarageProductPriceByRent = await clientAvarageProductPriceByRent.GetAsync(_apiSettings.BaseUrl + "Statistic/AvarageProductPriceByRent");
            var jsonDataAvarageProductPriceByRent = await responseMessageAvarageProductPriceByRent.Content.ReadAsStringAsync();
            ViewBag.AvarageProductPriceByRent = float.Parse(jsonDataAvarageProductPriceByRent).ToString("#.00") ;
            #endregion
            return View();
        }
    }
}
