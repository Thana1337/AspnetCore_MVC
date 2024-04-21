
using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class AddressFactory
{


    public static AddressEntity Create()
    {
        try
        {
            return new AddressEntity();

        }
        catch { }
        return null!;
    }
    
    public static AddressEntity Create(string addressline_1, string? addressline_2,  string postalCode, string? city)
    {
        try
        {
            return new AddressEntity
            {
                Addressline_1 = addressline_1,
                Addressline_2 = addressline_2,
                PostalCode = postalCode,
                City = city
            };
        }
        catch { }
        return null!;
    }
}
