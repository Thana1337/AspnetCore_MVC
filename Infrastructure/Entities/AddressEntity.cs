

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;
public class AddressEntity
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Address line 1", Prompt = "Enter your address", Order = 0)]
    [Required(ErrorMessage = "You must enter your address")]
    public string Addressline_1 { get; set; } = null!;

    [Display(Name = "Address line 2", Prompt = "Enter your address", Order = 1)]
    public string? Addressline_2 { get; set; }

    [Display(Name = "Postalcode", Prompt = "Enter your postalcode", Order = 2)]
    [Required(ErrorMessage = "You must enter your postalcode")]
    [DataType(DataType.PostalCode)]
    public string PostalCode { get; set; } = null!;

    [Display(Name = "Last name", Prompt = "Enter your city", Order = 3)]
    [Required(ErrorMessage = "You must enter your city")]
    public string? City { get; set; }

    // Foreign key property
    public string UserId { get; set; }
    
    // Navigation property for the user
    public UserEntity User { get; set; }
}
