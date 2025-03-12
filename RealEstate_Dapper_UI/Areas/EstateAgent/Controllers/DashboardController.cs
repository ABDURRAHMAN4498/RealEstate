using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    [Route("EstateAgent/[controller]")]
    public class DashboardController : Controller
    {
        public IActionResult Index(){
            return View();
        }
    }
}