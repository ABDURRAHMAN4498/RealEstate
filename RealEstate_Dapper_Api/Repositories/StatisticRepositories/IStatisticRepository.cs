namespace RealEstate_Dapper_Api.Repositories.StatisticRepositories
{
    public interface IStatisticRepository
    {
        int CategoryCount();
        int ActiveCategoryCount();
        int PassiveCategoryCount();
        int ProductCount();
        int ApartmentCount();
        string EmployeeNameByMaxProductCount();
        string CategoryNameByMaxProductCount();
        decimal AvarageProductPriceBySale();
        public decimal AvarageProductPriceByRent();
        string CityNameByMaxProductCount();
        int DifferentCityCount();
        decimal LastProductPrice();
        string NewestbuildingYear();
        string OldestbuildingYear();
        int AvarageRoomCount();
        int ActiveEmployeeCount();

    }
}