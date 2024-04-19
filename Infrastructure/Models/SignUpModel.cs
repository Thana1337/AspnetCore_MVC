
using AspnetCore_MVC.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class SignUpModel
{
    [Display(Name = "FirstName", Prompt = "Enter your first name", Order = 0)]
    [MinLength(2, ErrorMessage = "You must enter a valid first name")]
    [Required(ErrorMessage = "You must enter your first name")]

    public string FirstName { get; set; } = null!;

    [Display(Name = "LastName", Prompt = "Enter your last name", Order = 1)]
    [MinLength(2, ErrorMessage = "You must enter a valid last name")]
    [Required(ErrorMessage = "You must enter your last name")]

    public string LastName { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Enter your email address", Order = 2)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
    [Required(ErrorMessage = "You must enter your email address")]
    public string Email { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "Password", Prompt = "Enter your password", Order = 3)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, one digit, one special character, and be at least 8 characters long")]
    [Required(ErrorMessage = "You must enter your password")]
    public string Password { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password", Prompt = "Confirm your password", Order = 4)]
    [Compare(nameof(Password), ErrorMessage = "The passwords do not match.")]
    [Required(ErrorMessage = "You must confirm your password")]

    public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "I agree to the Terms & Conditions.", Order = 5)]
    [CheckBoxRequired(ErrorMessage = "You must agree to the Terms & Conditions.")]
    public bool TermsNCondition { get; set; }
}
