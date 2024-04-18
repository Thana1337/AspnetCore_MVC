using AspnetCore_MVC.ViewModels;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspnetCore_MVC.Controllers
{
    public class AuthController(UserService userService) : Controller
    {
        private readonly UserService _userService = userService;

        [Route("/signup")]
        [HttpGet]
        public IActionResult SignUp()
        {
            var viewModel = new SignUpViewmodel();  
            return View(viewModel);
        }

        [Route("/signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewmodel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.CreateUserAsync(viewModel.Form);
                if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
                    return RedirectToAction("SignIn", "Auth");
            }

            return View(viewModel);
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
        public async Task<IActionResult> SignIn(SignInViewmodel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.SignInUserAsync(viewModel.Form);
                if (result.StatusCode == Infrastructure.Models.StatusCode.OK && result != null)
                {
                    var claims = new List<Claim>
                    {
                        
                    };

                    await HttpContext.SignInAsync("AuthCookie", new ClaimsPrincipal(new ClaimsIdentity(claims, "AuthCookie")));
                    return RedirectToAction("Index", "Account");
                }

            }
            viewModel.ErrorMessage = "Incorrect email or password";
            return View(viewModel);
        }

        [Route("/signout")]
        [HttpPost]
        public new async Task<IActionResult> SignOut(SignInViewmodel viewModel)
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Account");
        }

    }


}
