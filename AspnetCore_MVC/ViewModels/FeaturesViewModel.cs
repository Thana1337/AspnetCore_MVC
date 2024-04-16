
using AspnetCore_MVC.Models.Component;

namespace AspnetCore_MVC.ViewModels;

public class FeaturesViewModel
{
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }

    public List<FeatureComponent>? Features { get; set; }

}
