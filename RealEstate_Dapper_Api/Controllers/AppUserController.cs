using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_Api.Controllers;

public class AppUserController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}