using AspnetCore_MVC.Models.Component;
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
                    new() { ImageUrl = "Images/brand_2.svg", AltText = "Brand Name 2"},
                    new() { ImageUrl = "Images/brand_3.svg", AltText = "Brand Name 3"},
                    new() { ImageUrl = "Images/brand_4.svg", AltText = "Brand Name 4"}
                ],

            },

            Features = new FeaturesViewModel
            {
                Id = "feature",
                Title = "What Do You Get with Our Tool?",
                Text = "Make sure all your tasks are organized so you can set the priorities and focus on important.",
                Features = new List<FeatureComponent>
                {
                    new FeatureComponent { BoxId = "box-1" , ImageUrl = "/Images/chat.svg", AltText = "chatbox icon", Title = "Comments on Tasks", Text = "Id mollis consectetur congue egestas egestas suspendisse blandit justo."},
                    new FeatureComponent { BoxId = "box-2" , ImageUrl = "/Images/presentation.svg", AltText = "presentation icon", Title = "Tasks Analytics", Text = "Non imperdiet facilisis nulla tellus Morbi scelerisque eget adipiscing vulputate."},
                    new FeatureComponent { BoxId = "box-3" , ImageUrl = "/Images/add-group.svg", AltText = "add group icon", Title = "Multiple Assignees", Text = "A elementum, imperdiet enim, pretium etiam facilisi in aenean quam mauris."},
                    new FeatureComponent { BoxId = "box-4" , ImageUrl = "/Images/bell.svg", AltText = "bell icon", Title = "Notifications", Text = "Diam, suspendisse velit cras ac. Lobortis diam volutpat, eget pellentesque viverra."},
                    new FeatureComponent { BoxId = "box-5" , ImageUrl = "/Images/test.svg", AltText = "test icon", Title = "Sections & Subtasks", Text = "Mi feugiat hac id in. Sit elit placerat lacus nibh lorem ridiculus lectus."},
                    new FeatureComponent { BoxId = "box-6" , ImageUrl = "/Images/shield.svg", AltText = "shield icon", Title = "Data Security", Text = "Aliquam malesuada neque eget elit nulla vestibulum nunc cras."}
                }



            }


        };

        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }
}
