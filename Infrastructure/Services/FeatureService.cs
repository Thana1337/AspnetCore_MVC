using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class FeatureService(FeatureRepository featureReposotiry, FeatureContentRepository featureContentReposotiry)
{

    private readonly FeatureRepository _featureReposotiry = featureReposotiry;
    private readonly FeatureContentRepository _featureContentReposotiry = featureContentReposotiry;



    public async Task<ResponsResult> GetAllFeaturesAsync()
    {
        try
        {
            var result = await _featureReposotiry.GetAllAsync();
            return result;
        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }

}


