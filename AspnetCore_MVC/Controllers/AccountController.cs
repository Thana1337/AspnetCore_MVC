using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCore_MVC.Controllers;

public class AccountController : Controller
{

    [Authorize]
    public IActionResult Index()
    {
        return View();
    }
}
