using AspnetCore_MVC.Models.Component;
using Infrastructure.Entities;
using Infrastructure.Services;
using static System.Net.Mime.MediaTypeNames;

namespace AspnetCore_MVC.ViewModels;

public class HomeIndexViewModel
{
    private readonly FeatureService _featureService;

    public HomeIndexViewModel(FeatureService featureService)
    {
        _featureService = featureService;

        Task.Run(async () =>
        {
            var result = await _featureService.GetAllFeaturesAsync();
            var content = (FeatureEntity)result.ContentResult!;

            Features.Title = content.Title;
            Features.Text = content.Text;

            foreach (var item in content.FeatureContent)
                Features.FeatureContent.Add(item);

        });
    }

    public FeatureViewModel Features { get; set; } = new FeatureViewModel();

}








