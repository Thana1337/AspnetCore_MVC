using Infrastructure.Entities;
using Infrastructure.Models;

namespace AspnetCore_MVC.ViewModels

{
    public class AccountDetailViewModel
    {
        public string Title { get; set; } = "Account Details";

        public UserEntity User { get; set; } = null!;

        public AccountDetailBasicInfo BasicInfo { get; set; } = new AccountDetailBasicInfo();
        public AccountDetailAddressInfo AddressInfo { get; set; } = new AccountDetailAddressInfo();
    }
}
