using AspnetCore_MVC.Models;

namespace AspnetCore_MVC.ViewModels;

public class CourseViewModel
{
    public IEnumerable<CourseModel> Courses { get; set; } = [];
}
