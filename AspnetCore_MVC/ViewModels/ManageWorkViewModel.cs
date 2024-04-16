using AspnetCore_MVC.Models.Component;

namespace AspnetCore_MVC.ViewModels
{
    public class ManageWorkViewModel
    {
        public string? Id { get; set; }
        public string? Title { get; set; }

        public List<ManageWorkList> ManageWorkLists { get; set; } = null!;
        public ImageViewModel ManageWorkImg { get; set; } = null!;
        public LinkViewModel Link { get; set; } = new LinkViewModel();
    }
}
