using AspnetCore_MVC.Models.Component;

namespace AspnetCore_MVC.ViewModels;

public class ShowcaseViewmodel
{
    public string? Id { get; set; }
    public ImageViewModel ShowcaseImg { get; set; } = null!;
    public string? Title { get; set; }
    public string? Text { get; set; }

    public string? BrandText { get; set; }

    public LinkViewModel Link { get; set; } = new LinkViewModel();

    public List<ImageViewModel>? Brands { get; set; }



}
