using AspnetCore_MVC.Models.Component;
using Infrastructure.Entities;
using Infrastructure.Services;
using static System.Net.Mime.MediaTypeNames;

namespace AspnetCore_MVC.ViewModels;

public class HomeIndexViewModel
{
    public string Title { get; set; } = null!;
        
    public FeatureViewModel Feature { get; set; } = null!;
    public ShowCaseViewModel ShowCase { get; set; } = null!;
    public MockupViewModel Mockup { get; set; } = null!;
    public ManageWorkViewModel ManageWork { get; set; } = null!;
    public AppViewModel App { get; set; } = null!;

    public IntegrateViewModel Integrate { get; set; } = null!;


}











