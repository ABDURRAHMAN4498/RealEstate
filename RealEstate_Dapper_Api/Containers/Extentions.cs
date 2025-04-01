using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.AppUserRepositories;
using RealEstate_Dapper_Api.Repositories.BottomGridRepository;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.ContactRepositories;
using RealEstate_Dapper_Api.Repositories.EmployeeRepositories;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepoository;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;
using RealEstate_Dapper_Api.Repositories.MessageRepositories;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepository;
using RealEstate_Dapper_Api.Repositories.ProductImageRepositories;
using RealEstate_Dapper_Api.Repositories.ProductRepository;
using RealEstate_Dapper_Api.Repositories.PropertyAmenityRepositories;
using RealEstate_Dapper_Api.Repositories.ServiceRepository;
using RealEstate_Dapper_Api.Repositories.StatisticRepositories;
using RealEstate_Dapper_Api.Repositories.SubFreatureRepositories;
using RealEstate_Dapper_Api.Repositories.TesimonialRepository;
using RealEstate_Dapper_Api.Repositories.ToDoListRepositories;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;
namespace RealEstate_Dapper_Api.Container
{
    public static class Extentions
    {
        public static void ContainerDependencies(this IServiceCollection Services)
        {
            Services.AddTransient<Context>();
            Services.AddTransient<ICategoryRepository, CategoryRepository>();
            Services.AddTransient<IProductRepository, ProductRepository>();
            Services.AddTransient<IWhoWeAreRepository, WhoWeAreRepository>();
            Services.AddTransient<IServiceRepository, ServiceRepository>();
            Services.AddTransient<IBottomGridRepository, BottomGridRepository>();
            Services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
            Services.AddTransient<ITesimonialRepository, TesimonialRepository>();
            Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            Services.AddTransient<IStatisticsRepository, StatisticsRepository>();
            Services.AddTransient<IStatisticRepository, StatisticRepository>();
            Services.AddTransient<IContactRepository, ContactRepository>();
            Services.AddTransient<IToDoListRepository, ToDoListRepository>();
            Services.AddTransient<IChartRepository, ChartRepository>();
            Services.AddTransient<ILast5ProductsRepository, Last5ProductsRepository>();
            Services.AddTransient<IMessageRepository, MessageRepository>();
            Services.AddTransient<IProductImageRepository, ProductImageRepository>();
            Services.AddTransient<IAppUserRepository, AppUserRepository>();
            Services.AddTransient<IPropertyAmenityRepository, PropertyAmenityRepository>();
            Services.AddTransient<ISubFreatureRepository, SubFreatureRepository>();

        }
    }
}