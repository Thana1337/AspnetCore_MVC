using AspnetCore_MVC.Models.Component;

namespace AspnetCore_MVC.ViewModels;

public class IntegrateViewModel
{
    public string? Id { get; set; }
    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public List<WorkTools> WorkTools { get; set; } = null!;



}
