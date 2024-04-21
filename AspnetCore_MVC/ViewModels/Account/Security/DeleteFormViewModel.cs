using AspnetCore_MVC.Helpers;
using System.ComponentModel.DataAnnotations;

namespace AspnetCore_MVC.ViewModels.Account.Security;

public class DeleteFormViewModel
{
    [Required]
    [Display(Name = "Yes, I want to delete my account.")]
    [CheckBoxRequired(ErrorMessage = "You must agree to the Terms & Conditions.")]
    public bool TermsNCondition { get; set; }

}
