using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public ToDoListController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IActionResult> Index(){
            return View();
        }
    }
}