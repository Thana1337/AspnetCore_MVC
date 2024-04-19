namespace Infrastructure.Entities;

public class FeatureEntity
{
    public string? Id { get; set; }
    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;

    public ICollection<FeatureContentEntity> FeatureContent { get; set; } = [];


}
