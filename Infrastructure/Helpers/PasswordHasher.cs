

using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Helpers;

public class PasswordHasher
{
    public static (string, string) GenerateHash(string password)
    {
        using var hmac = new HMACSHA512();
        var securityKey = hmac.Key;
        var hashedpassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));


        return (Convert.ToBase64String(securityKey), Convert.ToBase64String(hashedpassword));
    }

    public static bool ValidateSecurePassword(string password, string hash,  string securityKey)
    {
        using var hmac = new HMACSHA512(Convert.FromBase64String(securityKey));
        var hashedpassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        var userPassword = Convert.FromBase64String(hash);

        for(var i=0; i<hashedpassword.Length; i++)
        {
            if (hashedpassword[i] != userPassword[i])
                return false;
        }
        return true;
    }
}
