using AspnetCore_MVC.Helpers;
using System.ComponentModel.DataAnnotations;

namespace AspnetCore_MVC.ViewModels.Account.Security;

public class PassWordFormViewModel
{
    [DataType(DataType.Password)]
    [Display(Name = "Current Password", Prompt = "Enter your password", Order = 3)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, one digit, one special character, and be at least 8 characters long")]
    [Required(ErrorMessage = "You must enter your password")]
    public string NewPassword { get; set; } = null!;


    [DataType(DataType.Password)]
    [Display(Name = "New password", Prompt = "Enter a new password", Order = 4)]
    [Required(ErrorMessage = "You must enter a password")]
    public string OldPassword { get; set; } = null!;
    [DataType(DataType.Password)]

    [Display(Name = "Confirm new password", Prompt = "Confirm your new password", Order = 4)]
    [Required(ErrorMessage = "You must confirm your password")]
    public string PasswordConfirm { get; set;} = null!;

    public string UserId { get; set; } = null!;



}
