namespace Infrastructure.Entities;

public class FeatureContentEntity
{
    public string? Id { get; set; } 
    public string? BoxId { get; set; }
    public FeatureEntity Feature { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public string? AltText { get; set; }

    public string? Title { get; set; }

    public string? Text { get; set; }


}


