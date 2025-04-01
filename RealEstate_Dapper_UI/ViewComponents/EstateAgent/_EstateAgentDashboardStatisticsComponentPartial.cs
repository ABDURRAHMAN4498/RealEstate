using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RealEstate_Dapper_UI.Models;
using RealEstate_Dapper_UI.Services;
namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly ApiSettings _apiSettings;
        public _EstateAgentDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService,IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _apiSettings = apiSettings.Value;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;
            #region ProductCount - Toplam ilan sayısı
            var clientProductCount = _httpClientFactory.CreateClient();
            var responseMessageProductCount = await clientProductCount.GetAsync(_apiSettings.BaseUrl +
             $"EstateAgentDashboardStatistic/AllProductCount");
            var jsonDataProductCount = await responseMessageProductCount.Content.ReadAsStringAsync();
            ViewBag.AllProductCount = jsonDataProductCount;
            #endregion

            #region ProductCountByEmployeeId - Emlakçının Toplam İlan Sayısı
            var clientProductCountByEmployeeId = _httpClientFactory.CreateClient();
            var responseMessageProductCountByEmployeeId = await clientProductCountByEmployeeId.GetAsync(_apiSettings.BaseUrl +
             $"EstateAgentDashboardStatistic/ProductCountByEmployeeId?id={id}");
            var jsonDataProductCountByEmployeeId = await responseMessageProductCountByEmployeeId.Content.ReadAsStringAsync();
            ViewBag.ProductCountByEmployeeId = jsonDataProductCountByEmployeeId;
            #endregion

            #region DifferentCityCount - AktifİlanSayisi
            var clientProductCountByStatusTrue = _httpClientFactory.CreateClient();
            var responseMessageProductCountByStatusTrue = await clientProductCountByStatusTrue.GetAsync(_apiSettings.BaseUrl +
             $"EstateAgentDashboardStatistic/ProductCountByStatusTrue?id={id}");
            var jsonDataProductCountByStatusTrue = await responseMessageProductCountByStatusTrue.Content.ReadAsStringAsync();
            ViewBag.ProductCountByStatusTrue = jsonDataProductCountByStatusTrue;
            #endregion

            #region ProductCountByStatusFalse - PasifİlanSayısı
            var clientProductCountByStatusFalse = _httpClientFactory.CreateClient();
            var responseMessageProductCountByStatusFalse = await clientProductCountByStatusFalse.GetAsync(_apiSettings.BaseUrl +
             $"EstateAgentDashboardStatistic/ProductCountByStatusFalse?id={id}");
            var jsonDataProductCountByStatusFalse = await responseMessageProductCountByStatusFalse.Content.ReadAsStringAsync();
            ViewBag.ProductCountByStatusFalse = int.Parse(jsonDataProductCountByStatusFalse);
            #endregion
            return View();
        }
    }
}