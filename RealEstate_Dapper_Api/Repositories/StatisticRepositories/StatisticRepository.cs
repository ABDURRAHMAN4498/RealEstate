using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly Context _context;

        public StatisticRepository(Context context)
        {
            _context = context;
        }

        public int ActiveCategoryCount()
        {
            string query = "select Count(*) from Category where CategoryStatus = 1";
            using (var connection = _context.CreaConnection())
            {
                int value = connection.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public int ActiveEmployeeCount()
        {
            string query = "select Count(*) from Employee where Status = 1";
            using (var connection = _context.CreaConnection())
            {
                int value = connection.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public int ApartmentCount()
        {
            string query = "select Count(*) from Product where Title Like '%Daire%' ";
            using (var connection = _context.CreaConnection())
            {
                int value = connection.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public decimal AvarageProductPriceBySale()
        {
            string query = "select Avg(Price) from Product where Type='Satılık'";
            using (var connection = _context.CreaConnection())
            {
                var value = connection.QueryFirstOrDefault<decimal>(query);
                return value;
            }
        }
        public decimal AvarageProductPriceByRent()
        {
            string qurey = "select Avg(Price) from Product where Type='Kiralık'";
            using (var connection = _context.CreaConnection())
            {
                var value = connection.QueryFirstOrDefault<decimal>(qurey);
                return value;
            }
        }

        public int AvarageRoomCount()
        {
            string query = "select Avg(RoomCount) from ProductDetails";
            using (var connection = _context.CreaConnection()) {
                var value = connection.QueryFirstOrDefault<int>(query);
                return value;
             }
        }

        public int CategoryCount()
        {
            string query = "select Count(*) from Category";
            using (var connection = _context.CreaConnection()) {
                var value = connection.QueryFirstOrDefault<int>(query);
                return value;
             }
            throw new NotImplementedException();
        }

        public string CategoryNameByMaxProductCount()
        {
            string query = "select top(1)  CategoryName , Count(*) from Product inner join Category on Product.ProductCategory=Category.CategoryId Group by CategoryName Order by Count(*) desc";
            using(var connection = _context.CreaConnection()) 
            {
                var value = connection.QueryFirstOrDefault<string>(query);
                return value;
            }
        }

        public string CityNameByMaxProductCount()
        {
            string query = "select top(1) City,Count(*) as 'IlanSayisi' from Product Group by City Order by  IlanSayisi Desc;";
            using(var connection = _context.CreaConnection())
            {
                var value = connection.QueryFirstOrDefault<string>(query);
                return value;
            }
            
        }

        public int DifferentCityCount()
        {
            string query = "select count(distinct(City)) from Product";
            using(var connection = _context.CreaConnection()){
                var value = connection.QueryFirstOrDefault<int>(query);
                return value;
            }
            
        }

        public string EmployeeNameByMaxProductCount()
        {
            string query = "select top(1) Name,Count(*) 'product_count' from Product inner join Employee on Product.EmplooyeId=Employee.EmployeeId Group by Name order by product_count desc";
            using(var connection = _context.CreaConnection()){
                var value = connection.QueryFirstOrDefault<string>(query);
                return value;
            }
        }

        public decimal LastProductPrice()
        {
            string query = "select top(1) Price from Product Order by ProductId desc";
            using (var connection = _context.CreaConnection()){
                var value = connection.QueryFirstOrDefault<decimal>(query);
                return value;
            }
        }

        public string NewestbuildingYear()
        {
            string query="select top(1) BuildYear from ProductDetails order by BuildYear desc";
            using(var connection = _context.CreaConnection()){
                var value = connection.QueryFirstOrDefault<string>(query);
                return value;
            }
        }

        public string OldestbuildingYear()
        {
            string query="select top(1) BuildYear from ProductDetails order by BuildYear asc";
            using(var connection = _context.CreaConnection()){
                var value = connection.QueryFirstOrDefault<string>(query);
                return value;
            }
        }

        public int PassiveCategoryCount()
        {
            string query = "select count(*) from Category where CategoryStatus=0;";
            using(var connection = _context.CreaConnection()){
                var value = connection.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public int ProductCount()
        {
            string query = "select count(*) from Product";
            using(var connection = _context.CreaConnection()){
                var value = connection.QueryFirstOrDefault<int>(query);
                return value;
            }
        }
    }
}