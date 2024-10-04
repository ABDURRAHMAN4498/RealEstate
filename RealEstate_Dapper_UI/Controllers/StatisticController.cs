using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.StaticValues;

namespace RealEstate_Dapper_UI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ActionResult> Index()
        {
            #region ActiveCategoryCount
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(PublicValues.Url+ "Statistic/ActiveCategoryCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.activeCateoryCount = jsonData;
            #endregion

            #region ActiveEmployeeCount
            var clientActiveEmployeeCount = _httpClientFactory.CreateClient();
            var responseMessageActiveEmployeeCount = await client.GetAsync(PublicValues.Url + "Statistic/ActiveEmployeeCount");
            var jsonDataActiveEmployeeCount = await responseMessageActiveEmployeeCount.Content.ReadAsStringAsync();
            ViewBag.ActiveEmployeeCount = jsonDataActiveEmployeeCount;
            #endregion

            #region ApartmentCount
            var clientApartmentCount = _httpClientFactory.CreateClient();
            var responseMessageApartmentCount = await client.GetAsync(PublicValues.Url + "Statistic/ActiveCategoryCount");
            var jsonDataApartmentCount = await responseMessageApartmentCount.Content.ReadAsStringAsync();
            ViewBag.ApartmentCount = jsonDataApartmentCount;
            #endregion

            #region AvarageProductPriceByRent
            var clientAvarageProductPriceByRent = _httpClientFactory.CreateClient();
            var responseMessageAvarageProductPriceByRent = await clientAvarageProductPriceByRent.GetAsync(PublicValues.Url + "Statistic/AvarageProductPriceByRent");
            var jsonDataAvarageProductPriceByRent = await responseMessageAvarageProductPriceByRent.Content.ReadAsStringAsync();
            ViewBag.AvarageProductPriceByRent = jsonDataAvarageProductPriceByRent;
            #endregion

            #region AvarageProductPriceBySalev
            var clientAvarageProductPriceBySale = _httpClientFactory.CreateClient();
            var responseMessageAvarageProductPriceBySale = await clientAvarageProductPriceBySale.GetAsync(PublicValues.Url + "Statistic/AvarageProductPriceBySale");
            var jsonDataAvarageProductPriceBySale = await responseMessageAvarageProductPriceBySale.Content.ReadAsStringAsync();
            ViewBag.AvarageProductPriceBySale = jsonDataAvarageProductPriceBySale;
            #endregion

            #region AvarageRoomCount
            var clientAvarageRoomCount = _httpClientFactory.CreateClient();
            var responseMessageAvarageRoomCount = await clientAvarageRoomCount.GetAsync(PublicValues.Url + "Statistic/ActiveCategoryCount");
            var jsonDataAvarageRoomCount = await responseMessageAvarageRoomCount.Content.ReadAsStringAsync();
            ViewBag.AvarageRoomCount = jsonDataAvarageRoomCount;
            #endregion

            #region CategoryCount
            var clientCategoryCount = _httpClientFactory.CreateClient();
            var responseMessageCategoryCount = await clientCategoryCount.GetAsync(PublicValues.Url + "Statistic/CategoryCount");
            var jsonDataCategoryCount = await responseMessageCategoryCount.Content.ReadAsStringAsync();
            ViewBag.CategoryCount = jsonDataCategoryCount;
            #endregion

            #region CategoryNameByMaxProductCount
            var clientCategoryNameByMaxProductCount = _httpClientFactory.CreateClient();
            var responseMessageCategoryNameByMaxProductCount = await clientCategoryNameByMaxProductCount.GetAsync(PublicValues.Url + "Statistic/CategoryNameByMaxProductCount");
            var jsonDataCategoryNameByMaxProductCount = await responseMessageCategoryNameByMaxProductCount.Content.ReadAsStringAsync();
            ViewBag.CategoryNameByMaxProductCount = jsonDataCategoryNameByMaxProductCount;
            #endregion



            #region CityNameByMaxProductCount
            var clientCityNameByMaxProductCount = _httpClientFactory.CreateClient();
            var responseMessageCityNameByMaxProductCount = await clientCityNameByMaxProductCount.GetAsync(PublicValues.Url + "Statistic/CityNameByMaxProductCount");
            var jsonDataCityNameByMaxProductCount = await responseMessageCityNameByMaxProductCount.Content.ReadAsStringAsync();
            ViewBag.CityNameByMaxProductCount = jsonDataCityNameByMaxProductCount;
            #endregion

            #region DifferentCityCount
            var clientDifferentCityCount = _httpClientFactory.CreateClient();
            var responseMessageDifferentCityCount = await clientDifferentCityCount.GetAsync(PublicValues.Url + "Statistic/DifferentCityCount");
            var jsonDataDifferentCityCount = await responseMessageDifferentCityCount.Content.ReadAsStringAsync();
            ViewBag.DifferentCityCount = jsonDataDifferentCityCount;
            #endregion

            #region EmployeeNameByMaxProductCount
            var clientEmployeeNameByMaxProductCount = _httpClientFactory.CreateClient();
            var responseMessageEmployeeNameByMaxProductCount = await clientEmployeeNameByMaxProductCount.GetAsync(PublicValues.Url + "Statistic/EmployeeNameByMaxProductCount");
            var jsonDataEmployeeNameByMaxProductCount = await responseMessageEmployeeNameByMaxProductCount.Content.ReadAsStringAsync();
            ViewBag.EmployeeNameByMaxProductCount = jsonDataEmployeeNameByMaxProductCount;
            #endregion

            #region LastProductPrice
            var clientLastProductPrice = _httpClientFactory.CreateClient();
            var responseMessageLastProductPrice = await clientLastProductPrice.GetAsync(PublicValues.Url + "Statistic/LastProductPrice");
            var jsonDataLastProductPrice = await responseMessageLastProductPrice.Content.ReadAsStringAsync();
            ViewBag.LastProductPrice = jsonDataLastProductPrice;
            #endregion

            #region NewestbuildingYear
            var clientNewestbuildingYear = _httpClientFactory.CreateClient();
            var responseMessageNewestbuildingYear = await clientNewestbuildingYear.GetAsync(PublicValues.Url + "Statistic/NewestbuildingYear");
            var jsonDataNewestbuildingYear = await responseMessageNewestbuildingYear.Content.ReadAsStringAsync();
            ViewBag.NewestbuildingYear = jsonDataNewestbuildingYear;
            #endregion

            #region OldestbuildingYear
            var clientOldestbuildingYear = _httpClientFactory.CreateClient();
            var responseMessageOldestbuildingYear = await clientOldestbuildingYear.GetAsync(PublicValues.Url + "Statistic/OldestbuildingYear");
            var jsonDataOldestbuildingYear = await responseMessageOldestbuildingYear.Content.ReadAsStringAsync();
            ViewBag.OldestbuildingYear = jsonDataOldestbuildingYear;
            #endregion

            #region PassiveCategoryCount
            var clientPassiveCategoryCount = _httpClientFactory.CreateClient();
            var responseMessagePassiveCategoryCount = await clientPassiveCategoryCount.GetAsync(PublicValues.Url + "Statistic/PassiveCategoryCount");
            var jsonDataPassiveCategoryCount = await responseMessagePassiveCategoryCount.Content.ReadAsStringAsync();
            ViewBag.PassiveCategoryCount = jsonDataPassiveCategoryCount;
            #endregion


            #region ProductCount
            var clientProductCount = _httpClientFactory.CreateClient();
            var responseMessageProductCount = await clientProductCount.GetAsync(PublicValues.Url + "Statistic/ProductCount");
            var jsonDataProductCount = await responseMessageProductCount.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonDataProductCount;
            #endregion

            //#region ApartmentCount
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync(PublicValues.Url + "Statistic/ActiveCategoryCount");
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //ViewBag.ApartmentCount = jsonData;
            //#endregion

            //#region ApartmentCount
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync(PublicValues.Url + "Statistic/ActiveCategoryCount");
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //ViewBag.ApartmentCount = jsonData;
            //#endregion


            return View();
        }
    }
}
