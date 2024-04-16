using AspnetCore_MVC.Models.Component;

namespace AspnetCore_MVC.ViewModels
{
    public class AppViewModel
    {
        public string? Id { get; set; }
        public string? Title { get; set; }

        public ImageViewModel Image { get; set; } = null!;

        public List<AppRating> Apps { get; set; } = null!;




    }
}
