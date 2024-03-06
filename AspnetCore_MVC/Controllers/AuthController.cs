using Microsoft.AspNetCore.Mvc;

namespace AspnetCore_MVC.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

    }
}
