using Infrastructure.Entities;

namespace AspnetCore_MVC.ViewModels;

public class FeatureViewModel
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;
    public List<FeatureContentEntity> FeatureContent { get; set; } = [];
}








