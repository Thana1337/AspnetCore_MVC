using AspnetCore_MVC.Helpers;
using System.ComponentModel.DataAnnotations;
namespace AspnetCore_MVC.Models;

public class SignUpModel
{
    [Display(Name = "FirstName", Prompt = "Enter your first name", Order = 0)]
    [Required(ErrorMessage = "You must enter your first name")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "LastName", Prompt = "Enter your last name", Order = 1)]
    [Required(ErrorMessage = "You must enter your last name")]
    public string LastName { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Enter your email address", Order = 2)]
    [Required(ErrorMessage = "You must enter your email address")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "Password", Prompt = "Enter your password", Order = 3)]
    [Required(ErrorMessage = "You must enter your password")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, one digit, one special character, and be at least 8 characters long")]
    public string Password { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password", Prompt = "Confirm your password", Order = 4)]
    [Required(ErrorMessage = "You must enter your password")]
    [Compare(nameof(Password), ErrorMessage = "The passwords do not match.")]
    public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "I agree to the Terms & Conditions.", Order = 5)]
    [CheckBoxRequired(ErrorMessage = "You must agree to the Terms & Conditions.")]
    public bool TermsNCondition { get; set; }
}
 
