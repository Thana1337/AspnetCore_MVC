using AspnetCore_MVC.Models;

namespace AspnetCore_MVC.ViewModels;

public class AccountDetailsViewmodel
{
    public string Title { get; set; } = "Account Details";

    public AccountDetailBasicInfoModel BasicInfo { get; set; } = new AccountDetailBasicInfoModel();
    public AccountDetailAddressInfoModel AddressInfo { get; set; } = new AccountDetailAddressInfoModel();
}
