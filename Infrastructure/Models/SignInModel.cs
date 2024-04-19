
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class SignInModel
{
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Enter your email address", Order = 0)]
    [Required(ErrorMessage = "You must enter your email address")]
    public string Email { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "Password", Prompt = "Enter your password", Order = 1)]
    [Required(ErrorMessage = "You must enter your password")]
    public string Password { get; set; } = null!;


    [Display(Name = "RememberMe", Order = 2)]
    public bool RememberMe { get; set; }
}
