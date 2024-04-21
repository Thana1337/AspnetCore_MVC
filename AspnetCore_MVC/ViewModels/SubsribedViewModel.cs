using System.ComponentModel.DataAnnotations;

namespace AspnetCore_MVC.ViewModels;

public class SubsribedViewModel
{
    [Display(Name ="Subscribe", Prompt ="Enter your email")]
    [Required]
    public string Email { get; set; } = null!;

    public bool IsSubbed { get; set; } = false;
}
