using AspnetCore_MVC.Models.Component;
using Infrastructure.Entities;

namespace AspnetCore_MVC.ViewModels;

public class FeatureViewModel
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;
    public List<FeatureComponent> FeatureContent { get; set; } = new List<FeatureComponent>();
}








