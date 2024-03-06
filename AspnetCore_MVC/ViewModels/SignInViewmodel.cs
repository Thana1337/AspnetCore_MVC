using AspnetCore_MVC.Models;

namespace AspnetCore_MVC.ViewModels;

public class SignInViewmodel
{
    public string Title { get; set; } = "Sign In";
    public SignInModel Form { get; set; } = new SignInModel();

    public string? ErrorMessage { get; set; }
}
