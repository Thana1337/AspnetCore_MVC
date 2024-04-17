
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
            var result = await _repository.AlreadyExistAsync(x => x.Email == model.Email);
            if (result.StatusCode != StatusCode.EXIST)
            {
                result = await _repository.CreateOneAsync(UserFactory.Create(model));
                if (result.StatusCode == StatusCode.OK)
                {
                    return ResponseFactory.Ok("User Created");
                }
                return result;
            }

            return result;
        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }

    }
        
}
