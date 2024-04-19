﻿

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class UserEntity : IdentityUser
{
    private static readonly List<AddressEntity> addressEntities = new List<AddressEntity>();

    [Key]
    [Required]
    [Display(Name = "First Name")]
    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;
    [Required]
    [Display(Name = "First Name")]
    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string SecurityKey { get; set; } = null!;

    public string? Biography {  get; set; }

    public string? Phone { get; set; }


    public DateTime? Created { get; set; }
    public DateTime? Modified { get; set; }

    public int? AddressId { get; set; }
    public AddressEntity? Address { get; set; }
}