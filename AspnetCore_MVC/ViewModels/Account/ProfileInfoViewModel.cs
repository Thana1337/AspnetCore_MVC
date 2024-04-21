namespace AspnetCore_MVC.ViewModels.Account;

public class ProfileInfoViewModel
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set;} = null!;
    public string Email { get; set; } = null!;

    public string ProfileImg { get; set; } = "~/Images/avatar.svg";

}
