using AspnetCore_MVC.Models.Component;

namespace AspnetCore_MVC.ViewModels;

public class ShowCaseViewModel
{
    public string Id { get; set; } = null!;
    public ImageViewModel ShowcaseImg { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;

    public string BrandText { get; set; } = null!;

    public LinkViewModel Link { get; set; } = new LinkViewModel();

    public List<ImageViewModel>? Brands { get; set; }



}
