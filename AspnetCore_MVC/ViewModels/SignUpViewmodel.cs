using AspnetCore_MVC.Models;

namespace AspnetCore_MVC.ViewModels;

public class SignUpViewmodel
{
    public string Title { get; set; } = "Sign Up";
    public SignUpModel Form { get; set; } = new SignUpModel();

    public bool TermsNCondition { get; set; } = false;
}
