
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Helpers;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services;

public class UserService(UserRepository repository, AddressService adderessService, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
{
    private readonly UserRepository _repository = repository;
    private readonly AddressService _addressService = adderessService;
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;


    public async Task<ResponsResult> CreateUserAsync(SignUpModel model)
    {
        try
        {
            var exists = await _repository.AlreadyExistAsync(x => x.Email == model.Email);

            if (exists.StatusCode == StatusCode.EXIST)
                return exists;

            var result = await _repository.CreateOneAsync(UserFactory.Create(model));
            if (result.StatusCode != StatusCode.OK)
                return result;

            return ResponseFactory.Ok("User Created");

        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }

    }

    public async Task<ResponsResult> UpdateUserAsync(UserEntity user)
    {
        try
        {
            var result = await _repository.UpdateAsync(user);
            if (result.StatusCode == StatusCode.OK)
                return ResponseFactory.Ok("User Updated");
            else
                return result;
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }

    public async Task<ResponsResult> GetUserByEmailAsync(string email)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
                return ResponseFactory.Ok(user);
            else
                return ResponseFactory.NotFound("User not found");
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }


    public async Task<ResponsResult> SignInUserAsync(SignInModel model)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (signInResult.Succeeded)
                {
                    return ResponseFactory.Ok();
                }
            }

            return ResponseFactory.Error("Incorrect Email or Password");
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }
}
