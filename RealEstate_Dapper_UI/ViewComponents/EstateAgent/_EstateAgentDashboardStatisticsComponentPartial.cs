using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Services;
using RealEstate_Dapper_UI.StaticValues;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _EstateAgentDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;
            #region ProductCount - Toplam ilan sayısı
            var clientProductCount = _httpClientFactory.CreateClient();
            var responseMessageProductCount = await clientProductCount.GetAsync(PublicValues.Url +
             $"EstateAgentDashboardStatistic/AllProductCount");
            var jsonDataProductCount = await responseMessageProductCount.Content.ReadAsStringAsync();
            ViewBag.AllProductCount = jsonDataProductCount;
            #endregion

            #region ProductCountByEmployeeId - Emlakçının Toplam İlan Sayısı
            var clientProductCountByEmployeeId = _httpClientFactory.CreateClient();
            var responseMessageProductCountByEmployeeId = await clientProductCountByEmployeeId.GetAsync(PublicValues.Url +
             $"EstateAgentDashboardStatistic/ProductCountByEmployeeId?id={id}");
            var jsonDataProductCountByEmployeeId = await responseMessageProductCountByEmployeeId.Content.ReadAsStringAsync();
            ViewBag.ProductCountByEmployeeId = jsonDataProductCountByEmployeeId;
            #endregion

            #region DifferentCityCount - AktifİlanSayisi
            var clientProductCountByStatusTrue = _httpClientFactory.CreateClient();
            var responseMessageProductCountByStatusTrue = await clientProductCountByStatusTrue.GetAsync(PublicValues.Url +
             $"EstateAgentDashboardStatistic/ProductCountByStatusTrue?id={id}");
            var jsonDataProductCountByStatusTrue = await responseMessageProductCountByStatusTrue.Content.ReadAsStringAsync();
            ViewBag.ProductCountByStatusTrue = jsonDataProductCountByStatusTrue;
            #endregion

            #region ProductCountByStatusFalse - PasifİlanSayısı
            var clientProductCountByStatusFalse = _httpClientFactory.CreateClient();
            var responseMessageProductCountByStatusFalse = await clientProductCountByStatusFalse.GetAsync(PublicValues.Url +
             $"EstateAgentDashboardStatistic/ProductCountByStatusFalse?id={id}");
            var jsonDataProductCountByStatusFalse = await responseMessageProductCountByStatusFalse.Content.ReadAsStringAsync();
            ViewBag.ProductCountByStatusFalse = int.Parse(jsonDataProductCountByStatusFalse);
            #endregion
            return View();
        }
    }
}