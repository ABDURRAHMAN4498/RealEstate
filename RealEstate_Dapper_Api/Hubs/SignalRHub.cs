using Microsoft.AspNetCore.SignalR;

namespace RealEstate_Dapper_Api.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalRHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task SendCategoryCount()
        {
            var clientCategoryCount = _httpClientFactory.CreateClient();
            var responseMessageCategoryCount = await clientCategoryCount.GetAsync("http://localhost:5092/api/Statistic/CategoryCount");
            var jsonDataCategoryCount = await responseMessageCategoryCount.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveCategoryCount", jsonDataCategoryCount);
        }
    }
}
