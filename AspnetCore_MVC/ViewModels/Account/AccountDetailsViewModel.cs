using Infrastructure.Entities;

namespace AspnetCore_MVC.ViewModels.Account;

public class AccountDetailsViewModel
{
    public ProfileInfoViewModel ProfileInfoForm { get; set; } = null!;
    public BasicInfoFormViewModel BasicInfoForm { get; set; } = null!;

    public AddressInfoFormViewModel AddressInfoForm { get; set; } = null!;
}
