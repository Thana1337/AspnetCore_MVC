namespace AspnetCore_MVC.Models.Component;

public class AppRating
{
    public string? Name { get; set; }

    public ImageViewModel AppLink { get; set; } = null!;

    public string? LinkToStore { get; set; }
    public string? Award { get; set; }

    public string? Rating { get; set; }

}
