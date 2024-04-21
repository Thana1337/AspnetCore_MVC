

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class UserEntity : IdentityUser
{
    [Key]
    [Required]
    [Display(Name = "First Name")]
    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;

    [Required]
    [Display(Name = "Last Name")]
    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;

    public string SecurityKey { get; set; } = null!;

    [Display(Name = "Bio")]
    [DataType(DataType.MultilineText)]
    public string? Biography { get; set; }

    public DateTime? Created { get; set; }
    public DateTime? Modified { get; set; }

    // Navigation property for addresses
    public ICollection<AddressEntity> Addresses { get; set; } = new List<AddressEntity>();
}
