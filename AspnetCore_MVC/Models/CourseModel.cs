namespace AspnetCore_MVC.Models;

public class CourseModel
{
    public string Id { get; set; } = null!;
    public string? Title { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public int Hours { get; set; }

    public bool IsBestSeller { get; set; }

    public decimal LikesInNumber { get; set; }
    public decimal LikesInProcent { get; set; }

    public string? Author { get; set; }
    public string? ImgUrl { get; set; }

}
