using AspnetCore_MVC.Models.Views;
using AspnetCore_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCore_MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var viewModel = new HomeIndexViewModel
        {
            Title = "Ultimate Task Management Assistant",
            Showcase = new ShowcaseViewmodel
            {
                Id = "overview",
                ShowcaseImg = new() { ImageUrl = "/Images/showcase_img.svg", AltText = "Tast Management Assitant"},
                Title = "Task Management Assistant You Gonna Love",
                Text = "We offer you a new generation of task management system. Plan, manage & track all your tasks in one flexible tool.",
                Link = new() { ControllerName = "Downloads" , ActionName = "Index", Text = "Get Started For Free"},
                BrandText = "Largest companies use our tool to work efficiently",
                Brands =
                [
                    new() { ImageUrl = "Images/brand_1.svg", AltText = "Brand Name 1"},
                    new() { ImageUrl = "Images/brand_1.svg", AltText = "Brand Name 2"},
                    new() { ImageUrl = "Images/brand_3.svg", AltText = "Brand Name 3"},
                    new() { ImageUrl = "Images/brand_4.svg", AltText = "Brand Name 4"}
                ],

            }
        };

        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }
}
