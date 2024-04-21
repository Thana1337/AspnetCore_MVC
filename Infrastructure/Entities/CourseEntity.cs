

namespace Infrastructure.Entities;

public class CourseEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
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
