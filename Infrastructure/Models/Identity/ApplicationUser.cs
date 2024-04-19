using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace Infrastructure.Models.Identity;

public class ApplicationUser : IdentityUser
{

    [Required]
    [Display (Name ="First Name")]
    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;
    [Required]
    [Display(Name = "Last Name")]
    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;

    public int? AddressId { get; set; }
    public AddressEntity? Address { get; set; }
}
