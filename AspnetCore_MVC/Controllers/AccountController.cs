using AspnetCore_MVC.ViewModels;
using AspnetCore_MVC.ViewModels.Account.Details;
using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AspnetCore_MVC.Controllers;

public class AccountController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, ApplicationDbContext context, AddressService addressService, UserService userService) : Controller
{


    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly AddressService _addressService = addressService;
    private readonly UserService _userService = userService;
    public readonly ApplicationDbContext _context = context;



    #region Auth

    [HttpGet]
    [Route("/signup", Name = "SignUp")]
    public IActionResult SignUp()
    {
        if (_signInManager.IsSignedIn(User))
            return RedirectToAction("Details", "Account");
        var viewModel = new SignUpViewmodel();
        return View(viewModel);
    }

    [HttpPost]
    [Route("/signup", Name = "SignUp")]
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
    [Route("/signin", Name = "SignIn")]
    public IActionResult SignIn()
    {
        if (_signInManager.IsSignedIn(User))
            return RedirectToAction("Details", "Account");

        var viewModel = new SignInViewmodel();
        return View(viewModel);

    }

    [HttpPost]
    [Route("/signin", Name = "SignIn")]
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
    [Route("/signout", Name = "SignOut")]
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("SignIn", "Account");


    }
    #endregion

    [HttpPost]
    #region PopulateInfo
    public async Task<BasicInfoFormViewModel> PopulateBasicInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);
            return new BasicInfoFormViewModel
            {
                UserId = user!.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber!,
                Biography = user.Biography,
            };
    }

    private async Task<AddressInfoFormViewModel> PopulateAddressInfoAsync()
    {
        try
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var address = await _addressService.GetAddressAsync(user.Id);
                if (address != null)
                {
                    return new AddressInfoFormViewModel
                    {
                        UserId = user.Id,
                        Addressline_1 = address.Addressline_1,
                        Addressline_2 = address.Addressline_2,
                        Postalcode = address.PostalCode,
                        City = address.City
                    };
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ERROR :: " + ex.Message);
        }

        return new AddressInfoFormViewModel();
    }

    public async Task<ProfileInfoViewModel> PopulateProfileInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user != null)
        {
            var profileInfoViewModel = new ProfileInfoViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email!,
            };

            return profileInfoViewModel;
        }
        return new ProfileInfoViewModel();
    }

    #endregion

    #region Details
    [HttpGet]
    [Route("/account/details", Name = "Details")]
    public async Task<IActionResult> Details()
    {
        if (!User.Identity!.IsAuthenticated)
        {
            return RedirectToAction("SignIn", "Account");
        }

        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("SignIn", "Account");
        }

        var viewModel = new AccountDetailsViewModel();

        viewModel.ProfileInfoForm = await PopulateProfileInfoAsync();
        viewModel.AddressInfoForm = await PopulateAddressInfoAsync();
        viewModel.BasicInfoForm = await PopulateBasicInfoAsync();

        return View(viewModel);
    }


    [HttpPost]
    [Route("/account/details", Name = "Details")]
    public async Task<IActionResult> Details(AccountDetailsViewModel viewModel)
    {
        if (viewModel.BasicInfoForm != null)
        {
            if (viewModel.BasicInfoForm.FirstName != null && viewModel.BasicInfoForm.LastName != null && viewModel.BasicInfoForm.Email != null)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null) 
                {
                    user.FirstName = viewModel.BasicInfoForm.FirstName;
                    user.LastName = viewModel.BasicInfoForm.LastName;
                    user.Email = viewModel.BasicInfoForm.Email;
                    user.PhoneNumber = viewModel.BasicInfoForm.PhoneNumber;
                    user.Biography = viewModel.BasicInfoForm.Biography;

                    var result = await _userManager.UpdateAsync(user);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("Error", "Something went wrong!");
                        ViewData["ErrorMessage"] = "Something went wrong!";
                    }
                }
            }
        }
        if (viewModel.AddressInfoForm != null)
        {
            if (viewModel.AddressInfoForm.Addressline_1 != null && viewModel.AddressInfoForm.Postalcode != null && viewModel.AddressInfoForm.City != null)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    var result = await _addressService.GetOrCreateAddressAsync(viewModel.AddressInfoForm.Addressline_1, viewModel.AddressInfoForm.Addressline_2!, viewModel.AddressInfoForm.Postalcode, viewModel.AddressInfoForm.City, user.Id);
                    if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
                    {
                        var address = (AddressEntity)result.ContentResult!;
                        address.Addressline_1 = viewModel.AddressInfoForm.Addressline_1;
                        address.Addressline_2 = viewModel.AddressInfoForm.Addressline_2;
                        address.PostalCode = viewModel.AddressInfoForm.Postalcode;
                        address.City = viewModel.AddressInfoForm.City;
                        address.UserId = user.Id;

                        var updateResult = await _addressService.UpdateAddressAsync(address);
                        if (updateResult)
                        {
                            ViewData["StatusMessage"] = "success|Address Information was saved successfully.";
                        }
                        else
                        {
                            ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to update address information.");
                            ViewData["StatusMessage"] = "danger|Something went wrong! Unable to update address information.";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to get or create address information.");
                        ViewData["StatusMessage"] = "danger|Something went wrong! Unable to get or create address information.";
                    }
                }
            }
        }
        viewModel.BasicInfoForm ??= await PopulateBasicInfoAsync();
        viewModel.AddressInfoForm = await PopulateAddressInfoAsync();
        viewModel.ProfileInfoForm ??= await PopulateProfileInfoAsync();

        return View(viewModel);
    }
    #endregion

    #region SaveBasicInfo
    [HttpPost]
    public async Task<IActionResult> SaveBasicInfo(AccountDetailsViewModel viewModel)
    {
        if (viewModel.BasicInfoForm != null)
        {
            if (viewModel.BasicInfoForm.FirstName != null && viewModel.BasicInfoForm.LastName != null && viewModel.BasicInfoForm.Email != null)
            {
                var user = await _userManager.GetUserAsync(User); // Retrieve user by Id

                if (user != null)
                {
                    // Check if the email address has changed
                    if (viewModel.BasicInfoForm.Email != user.Email)
                    {
                        // Check if the new email address already exists
                        var existingUser = await _userManager.FindByEmailAsync(viewModel.BasicInfoForm.Email);
                        if (existingUser != null && existingUser.Id != user.Id)
                        {
                            ModelState.AddModelError("Error", "The email address is already in use.");
                            // Re-populate the view model and return the view with the error message
                            viewModel.ProfileInfoForm = await PopulateProfileInfoAsync();
                            viewModel.AddressInfoForm = await PopulateAddressInfoAsync();
                            return View("Details", viewModel);
                        }
                    }

                    // Update user's information with values from BasicInfoFormViewModel
                    user.FirstName = viewModel.BasicInfoForm.FirstName;
                    user.LastName = viewModel.BasicInfoForm.LastName;
                    user.Email = viewModel.BasicInfoForm.Email;
                    user.PhoneNumber = viewModel.BasicInfoForm.PhoneNumber;
                    user.Biography = viewModel.BasicInfoForm.Biography;

                    var updateUserResult = await _userManager.UpdateAsync(user);
                    if (updateUserResult.Succeeded)
                    {
                        return RedirectToAction("Details", "Account");
                    }
                    else
                    {
                        foreach (var error in updateUserResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("Error", "User not found.");
                }
            }
        }

        viewModel.ProfileInfoForm = await PopulateProfileInfoAsync();
        viewModel.AddressInfoForm = await PopulateAddressInfoAsync();

        return View("Details", viewModel);
    }
    #endregion


    #region Address
    public async Task<IActionResult> SaveAddressInfo(AccountDetailsViewModel viewModel)
    {
        ModelState.Remove("ProfileInfoForm");
        ModelState.Remove("BasicInfoForm");
        ModelState.Remove("DeleteForm");
        ModelState.Remove("PassWordForm");
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            // Check if the viewModel contains an address
            if (viewModel.AddressInfoForm != null)
            {
                // Check if the address exists in the database
                var existingAddress = await _context.Addresses.FirstOrDefaultAsync(a => a.UserId == user.Id);

                if (existingAddress != null)
                {
                    // Update the existing address with the new values
                    existingAddress.Addressline_1 = viewModel.AddressInfoForm.Addressline_1;
                    existingAddress.Addressline_2 = viewModel.AddressInfoForm.Addressline_2;
                    existingAddress.PostalCode = viewModel.AddressInfoForm.Postalcode;
                    existingAddress.City = viewModel.AddressInfoForm.City;

                    // Save the changes to the database
                    _context.Addresses.Update(existingAddress);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    // If the address doesn't exist, create a new one
                    var addressEntity = new AddressEntity
                    {
                        Addressline_1 = viewModel.AddressInfoForm.Addressline_1,
                        Addressline_2 = viewModel.AddressInfoForm.Addressline_2,
                        PostalCode = viewModel.AddressInfoForm.Postalcode,
                        City = viewModel.AddressInfoForm.City,
                        UserId = user.Id
                    };

                    // Add the new address entity to the context
                    await _context.Addresses.AddAsync(addressEntity);
                    await _context.SaveChangesAsync();
                }
            }

            // Redirect to the details page or any other appropriate action
            return RedirectToAction("Details", "Account");
        }

        // If model state is not valid, return to the view with validation errors
        return View("Details",viewModel);
    }

    #endregion


    #region Security
    [HttpGet]
    [Route("/account/security")]
    public async Task<IActionResult> Security()
    {
        if (!User.Identity!.IsAuthenticated)
        {
            return RedirectToAction("SignIn", "Account");
        }

        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("SignIn", "Account");
        }

        var viewModel = new AccountDetailsViewModel();

        viewModel.ProfileInfoForm = await PopulateProfileInfoAsync();

        return View(viewModel);
    }


    #endregion

}



