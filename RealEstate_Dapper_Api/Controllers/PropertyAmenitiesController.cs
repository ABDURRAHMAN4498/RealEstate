using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_Api.Controllers;

public class PropertyAmenitiesController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}