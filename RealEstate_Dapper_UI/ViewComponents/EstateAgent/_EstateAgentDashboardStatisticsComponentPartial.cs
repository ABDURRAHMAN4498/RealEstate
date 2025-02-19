using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.StaticValues;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _EstateAgentDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region ProductCount - Toplam ilan sayısı
            var clientProductCount = _httpClientFactory.CreateClient();
            var responseMessageProductCount = await clientProductCount.GetAsync(PublicValues.Url + $"EstateAgentDashboardStatistic/AllProductCount");
            var jsonDataProductCount = await responseMessageProductCount.Content.ReadAsStringAsync();
            ViewBag.AllProductCount = jsonDataProductCount;
            #endregion

            #region ProductCountByEmployeeId - Emlakçının Toplam İlan Sayısı
            var clientProductCountByEmployeeId = _httpClientFactory.CreateClient();
            var responseMessageProductCountByEmployeeId = await clientProductCountByEmployeeId.GetAsync(PublicValues.Url + $"EstateAgentDashboardStatistic/ProductCountByEmployeeId?id={1}");
            var jsonDataProductCountByEmployeeId = await responseMessageProductCountByEmployeeId.Content.ReadAsStringAsync();
            ViewBag.ProductCountByEmployeeId = jsonDataProductCountByEmployeeId;
            #endregion

            #region DifferentCityCount - AktifİlanSayisi
            var clientProductCountByStatusTrue = _httpClientFactory.CreateClient();
            var responseMessageProductCountByStatusTrue = await clientProductCountByStatusTrue.GetAsync(PublicValues.Url + $"EstateAgentDashboardStatistic/ProductCountByStatusTrue?id={1}");
            var jsonDataProductCountByStatusTrue = await responseMessageProductCountByStatusTrue.Content.ReadAsStringAsync();
            ViewBag.ProductCountByStatusTrue = jsonDataProductCountByStatusTrue;
            #endregion

            #region ProductCountByStatusFalse - PasifİlanSayısı
            var clientProductCountByStatusFalse = _httpClientFactory.CreateClient();
            var responseMessageProductCountByStatusFalse = await clientProductCountByStatusFalse.GetAsync(PublicValues.Url + $"EstateAgentDashboardStatistic/ProductCountByStatusFalse?id={1}");
            var jsonDataProductCountByStatusFalse = await responseMessageProductCountByStatusFalse.Content.ReadAsStringAsync();
            ViewBag.ProductCountByStatusFalse = float.Parse(jsonDataProductCountByStatusFalse).ToString("#.00") ;
            #endregion
            return View();
        }
    }
}