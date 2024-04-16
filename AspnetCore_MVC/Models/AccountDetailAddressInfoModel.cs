using System.ComponentModel.DataAnnotations;

namespace AspnetCore_MVC.Models;

public class AccountDetailAddressInfoModel
{
    [Display(Name = " Address line 1", Prompt = "Enter your address", Order = 0)]
    [Required(ErrorMessage = "You must enter your address")]
    public string Adressline_1 { get; set; } = null!;

    [Display(Name = " Address line 2", Prompt = "Enter your address", Order = 1)]
    public string? Adressline_2 { get; set; }

    [Display(Name = "Postalcode", Prompt = "Enter your postalcode", Order = 2)]
    [Required(ErrorMessage = "You must enter your postalcode")]
    [DataType(DataType.PostalCode)]
    public string Postalcode { get; set; } = null!;

    [Display(Name = "Last name", Prompt = "Enter your city", Order = 3)]
    [Required(ErrorMessage = "You must enter your city")]
    public string? City { get; set; }
}
