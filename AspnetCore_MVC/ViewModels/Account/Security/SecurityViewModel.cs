using AspnetCore_MVC.ViewModels.Account.Details;

namespace AspnetCore_MVC.ViewModels.Account.Security;

public class SecurityViewModel
{
    public PassWordFormViewModel PassWordForm { get; set; } = null!;
    public DeleteFormViewModel DeleteForm { get; set; } = null!;

}
