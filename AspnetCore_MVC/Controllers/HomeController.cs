using Microsoft.AspNetCore.Mvc;

namespace AspnetCore_MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [Route("/error")]
    public IActionResult Error(int statusCode)
    {
        return View();
    }
}
