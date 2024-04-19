using AspnetCore_MVC.ViewModels;

namespace AspnetCore_MVC.Models.Views;

public class HomeIndexViewModel
{
    public string Title { get; set; } = "";
    public ShowcaseViewmodel Showcase { get; set; } = null!;

    public MockupViewModel Mockup { get; set; } = null !;

    public ManageWorkViewModel ManageWork { get; set; } = null!;

    public AppViewModel App { get; set; } = null!;


}
