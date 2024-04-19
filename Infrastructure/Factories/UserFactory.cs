

using Infrastructure.Entities;
using Infrastructure.Helpers;
using Infrastructure.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Factories;

public class UserFactory
{
    public static UserEntity Create()
    {
        try
        {
            var date = DateTime.Now;
            return new UserEntity() 
            { 
                Id = Guid.NewGuid().ToString(), 
                Created = date,
                Modified = date,
            };
        }
        catch { }
        return null!;
    }

    public static UserEntity Create(SignUpModel model)
    {
        try
        {
            var date = DateTime.Now;
            var (password, sercurityKey) =  PasswordHasher.GenerateHash(model.Password);

            return new UserEntity 
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                Password = password,
                SecurityKey = sercurityKey,
                Created = date,
                Modified = date,
            };
        }
        catch { }
        return null!;
    }
}
