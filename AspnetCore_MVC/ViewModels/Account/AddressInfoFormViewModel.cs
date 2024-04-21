using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace AspnetCore_MVC.ViewModels.Account;

public class AddressInfoFormViewModel
{
    [BindNever]
    public string? UserId { get; set; } = null!;
    [Display(Name = " Address line 1", Prompt = "Enter your address line", Order = 0)]
    [Required(ErrorMessage = "You must enter your address")]
    public string Addressline_1 { get; set; } = null!;

    [Display(Name = " Address line 2", Prompt = "Enter your second address line", Order = 1)]
    public string? Addressline_2 { get; set; }

    [Display(Name = "Postalcode", Prompt = "Enter your postalcode", Order = 2)]
    [Required(ErrorMessage = "You must enter your postalcode")]
    [DataType(DataType.PostalCode)]
    public string Postalcode { get; set; } = null!;

    [Display(Name = "City", Prompt = "Enter your city", Order = 3)]
    [Required(ErrorMessage = "You must enter your city")]
    public string? City { get; set; }

}
