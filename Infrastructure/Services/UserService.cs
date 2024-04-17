
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Helpers;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class UserService(UserRepository repository, AdderessService adderessService)
{
    private readonly UserRepository _repository = repository;
    private readonly AdderessService _adderessService = adderessService;


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


    public async Task<ResponsResult> SignInUserAsync(SignInModel model)
    {
        try
        {
            var result = await _repository.GetOneAsync(x => x.Email == model.Email);

            if (result.StatusCode == StatusCode.OK && result.ContentResult != null)
            {
                var userEntity = (UserEntity)result.ContentResult;

                if (PasswordHasher.ValidateSecurePassword(model.Password, userEntity.Password, userEntity.SecurityKey))
                {
                    return ResponseFactory.Ok();
                }
            }

            return ResponseFactory.Error("Incorrect Email or Password");


            ;
        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }

    }

}
