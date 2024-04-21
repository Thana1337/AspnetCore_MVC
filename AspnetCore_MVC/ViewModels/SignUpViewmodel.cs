

using Infrastructure.Entities;
using Infrastructure.Models;

namespace AspnetCore_MVC.ViewModels;

public class SignUpViewmodel
{
    public string Title { get; set; } = "Sign Up";
    public SignUpModel Form { get; set; } = new SignUpModel();
}
