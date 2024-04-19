using AspnetCore_MVC.ViewModels;
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
