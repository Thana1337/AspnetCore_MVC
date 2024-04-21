using AspnetCore_MVC.ViewModels.Account.Security;
using Infrastructure.Entities;

namespace AspnetCore_MVC.ViewModels.Account.Details;

public class AccountDetailsViewModel
{
    public ProfileInfoViewModel ProfileInfoForm { get; set; } = null!;
    public BasicInfoFormViewModel BasicInfoForm { get; set; } = null!;

    public PassWordFormViewModel PassWordForm { get; set; } = null!;
    public DeleteFormViewModel DeleteForm { get; set; } = null!;

    public AddressInfoFormViewModel AddressInfoForm { get; set; } = null!;

}
