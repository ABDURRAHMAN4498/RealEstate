using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.StaticValues;
using System.Net.Http;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region ProductCount - Toplam ilan sayısı
            var clientProductCount = _httpClientFactory.CreateClient();
            var responseMessageProductCount = await clientProductCount.GetAsync(PublicValues.Url + "Statistic/ProductCount");
            var jsonDataProductCount = await responseMessageProductCount.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonDataProductCount;
            #endregion

            #region EmployeeNameByMaxProductCount - En Başarlı Personel
            var clientEmployeeNameByMaxProductCount = _httpClientFactory.CreateClient();
            var responseMessageEmployeeNameByMaxProductCount = await clientEmployeeNameByMaxProductCount.GetAsync(PublicValues.Url + "Statistic/EmployeeNameByMaxProductCount");
            var jsonDataEmployeeNameByMaxProductCount = await responseMessageEmployeeNameByMaxProductCount.Content.ReadAsStringAsync();
            ViewBag.EmployeeNameByMaxProductCount = jsonDataEmployeeNameByMaxProductCount;
            #endregion

            #region DifferentCityCount - ilandak şehir sayısı
            var clientDifferentCityCount = _httpClientFactory.CreateClient();
            var responseMessageDifferentCityCount = await clientDifferentCityCount.GetAsync(PublicValues.Url + "Statistic/DifferentCityCount");
            var jsonDataDifferentCityCount = await responseMessageDifferentCityCount.Content.ReadAsStringAsync();
            ViewBag.DifferentCityCount = jsonDataDifferentCityCount;
            #endregion

            #region AvarageProductPriceByRent - Ortalama Kira Fiyatı
            var clientAvarageProductPriceByRent = _httpClientFactory.CreateClient();
            var responseMessageAvarageProductPriceByRent = await clientAvarageProductPriceByRent.GetAsync(PublicValues.Url + "Statistic/AvarageProductPriceByRent");
            var jsonDataAvarageProductPriceByRent = await responseMessageAvarageProductPriceByRent.Content.ReadAsStringAsync();
            ViewBag.AvarageProductPriceByRent = float.Parse(jsonDataAvarageProductPriceByRent).ToString("0.00") ;
            #endregion
            return View();
        }
    }
}
