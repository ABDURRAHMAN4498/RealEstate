using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ToDoListDtos;
using RealEstate_Dapper_UI.StaticValues;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardToDoListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardToDoListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var resposeMessage = await client.GetAsync(PublicValues.Url+"ToDoLists/ToDoListList");
            if (resposeMessage.IsSuccessStatusCode)
            {
                var jsonData = await resposeMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultToDoListDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}