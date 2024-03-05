using Microsoft.AspNetCore.Mvc;

namespace AspnetCore_MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Ultimate Task Management Assistant";
        return View();
    }
}
