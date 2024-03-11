using AspnetCore_MVC.ViewModels;

namespace AspnetCore_MVC.Models.Views;

public class HomeIndexViewModel
{
    public string Title { get; set; } = "";
    public ShowcaseViewmodel Showcase { get; set; } = null!;

    public FeaturesViewModel Features { get; set; } = null!;

}
