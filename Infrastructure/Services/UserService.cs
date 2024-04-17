
using Infrastructure.Factories;
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


;
        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }

    }
        
}
