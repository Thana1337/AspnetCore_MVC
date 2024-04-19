using AspnetCore_MVC.ViewModels;

using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models.Identity;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AspnetCore_MVC.Controllers;

public class AccountController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager) : Controller
{


    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;

    [HttpGet]
    [Route("/signup")]
    public IActionResult SignUp()
    {
        if (_signInManager.IsSignedIn(User))
            return RedirectToAction("Details", "Account");
        var viewModel = new SignUpViewmodel();
        return View(viewModel);
    }

    [HttpPost]
    [Route("/signup")]
    public async Task<IActionResult> SignUp(SignUpViewmodel viewModel)
    {
        if (ModelState.IsValid)
        {

            var exist = await _userManager.Users.AnyAsync(x => x.Email == viewModel.Form.Email);
            if (exist)
            {
                ModelState.AddModelError("AlreadyExists", "User with the same email already exists");
                ViewData["ErrorMessage"] = "User with the same email already exists";
                return View();
            }

            var userEntity = UserFactory.Create(viewModel.Form);
            if (userEntity == null)
            {
                ModelState.AddModelError("CreationFailed", "Failed to create user.");
                return View(viewModel);
            }

            var result = await _userManager.CreateAsync(userEntity, viewModel.Form.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Account");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("CreationFailed", error.Description);
                }
            }
        }
        return View(viewModel);
    }
    [HttpGet]
    [Route("/signin")]
    public IActionResult SignIn()
    {
        if (_signInManager.IsSignedIn(User))
            return RedirectToAction("Details", "Account");

        var viewModel = new SignInViewmodel();
        return View(viewModel);

    }

    [HttpPost]
    [Route("/signin")]
    public async Task<IActionResult> SignIn(SignInViewmodel viewModel)
    {
       if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.Form.Email, viewModel.Form.Password, viewModel.Form.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Details", "Account");
            }

        }
        ModelState.AddModelError("IncorrectValues", "Incorrect email or password");
        ViewData["ErrorMessage"] = "Incorrect email or password";
        return View(viewModel);

    }


    [HttpGet]
    [Route("/signout")]
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("SignIn","Account");


    }

    [HttpGet]
    [Route("/account/details")]
    public async Task<IActionResult> Details()
    {
        if (!_signInManager.IsSignedIn(User))
            return RedirectToAction("SignIn", "Account");

        var userEntity = await _userManager.GetUserAsync(User);
        if (userEntity == null)
            return NotFound();

        var viewModel = new AccountDetailViewModel
        {
            User = userEntity!
        };


        return View(viewModel);


=======
using Microsoft.AspNetCore.Mvc;

namespace AspnetCore_MVC.Controllers;

public class AccountController : Controller
{
    [Route("/account")]
    public IActionResult Details()
    { 
        var viewModel = new AccountDetailsViewmodel();
        //viewModel.BasicInfo = _accountService.GetBasicInfo();
        //viewModel.AddressInfo = _accountService.AddressInfo();

        return View(viewModel); 
    }

    [HttpPost]
    public IActionResult BasicInfo(AccountDetailsViewmodel viewModel)
    {
        //_accountService.SaveBasicInfo(viewModel.BasicInfo);
        return RedirectToAction(nameof(Details));
    }

    [HttpPost]
    public IActionResult AddressInfo(AccountDetailsViewmodel viewModel)
    {
        //_accountService.SaveAddressInfo(viewModel.AddressInfo);
        return RedirectToAction(nameof(Details));
    }
}
