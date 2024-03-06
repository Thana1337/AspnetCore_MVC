using AspnetCore_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCore_MVC.Controllers
{
    public class AuthController : Controller
    {
        [Route("/signup")]
        [HttpGet]
        public IActionResult SignUp()
        {
            var viewModel = new SignUpViewmodel();  
            return View(viewModel);
        }

        [Route("/signup")]
        [HttpPost]
        public IActionResult SignUp(SignUpViewmodel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            return RedirectToAction("SignIn", "Auth");
        }


        [Route("/signin")]
        [HttpGet]
        public IActionResult SignIn()
        {
            var viewModel = new SignInViewmodel();
            return View(viewModel);
        }

        [Route("/signin")]
        [HttpPost]
        public IActionResult SignIn(SignInViewmodel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.ErrorMessage = "Incorrect email or password";
                return View(viewModel);
            }
            return RedirectToAction("Account", "Index");
        }

    }


}
