using AspnetCore_MVC.Models.Component;
using AspnetCore_MVC.ViewModels;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AspnetCore_MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var viewModel = new HomeIndexViewModel
        {

            Title = "Ultimate Task Management Assistant",

            ShowCase = new ShowCaseViewModel
            {
                Id = "overview",
                ShowcaseImg = new() { ImageUrl = "/Images/showcase_img.svg", AltText = "Tast Management Assitant" },
                Title = "Task Management Assistant You Gonna Love",
                Text = "We offer you a new generation of task management system. Plan, manage & track all your tasks in one flexible tool.",
                Link = new() { ControllerName = "Downloads", ActionName = "Index", Text = "Get Started For Free" },
                BrandText = "Largest companies use our tool to work efficiently",
                Brands =
                        [
                            new() { ImageUrl = "Images/brand_1.svg", AltText = "Brand Name 1" },
                            new() { ImageUrl = "Images/brand_2.svg", AltText = "Brand Name 2" },
                            new() { ImageUrl = "Images/brand_3.svg", AltText = "Brand Name 3" },
                            new() { ImageUrl = "Images/brand_4.svg", AltText = "Brand Name 4" }
                        ],

            },

            Feature = new FeatureViewModel
            {
                Id = "feature",
                Title = "What Do You Get with Our Tool?",
                Text = "Make sure all your tasks are organized so you can set the priorities and focus on important.",
                FeatureContent = new List<FeatureComponent>
                {
                    new FeatureComponent { BoxId = "box-1", ImageUrl = "/Images/chat.svg", AltText = "chatbox icon", Title = "Comments on Tasks", Text = "Id mollis consectetur congue egestas egestas suspendisse blandit justo." },
                    new FeatureComponent { BoxId = "box-2", ImageUrl = "/Images/presentation.svg", AltText = "presentation icon", Title = "Tasks Analytics", Text = "Non imperdiet facilisis nulla tellus Morbi scelerisque eget adipiscing vulputate." },
                    new FeatureComponent { BoxId = "box-3", ImageUrl = "/Images/add-group.svg", AltText = "add group icon", Title = "Multiple Assignees", Text = "A elementum, imperdiet enim, pretium etiam facilisi in aenean quam mauris." },
                    new FeatureComponent { BoxId = "box-4", ImageUrl = "/Images/bell.svg", AltText = "bell icon", Title = "Notifications", Text = "Diam, suspendisse velit cras ac. Lobortis diam volutpat, eget pellentesque viverra." },
                    new FeatureComponent { BoxId = "box-5", ImageUrl = "/Images/test.svg", AltText = "test icon", Title = "Sections & Subtasks", Text = "Mi feugiat hac id in. Sit elit placerat lacus nibh lorem ridiculus lectus." },
                    new FeatureComponent { BoxId = "box-6", ImageUrl = "/Images/shield.svg", AltText = "shield icon", Title = "Data Security", Text = "Aliquam malesuada neque eget elit nulla vestibulum nunc cras." }
                }
            },

            Mockup = new MockupViewModel()
            {
                Id = "mockup"
            },

            ManageWork = new ManageWorkViewModel()
            {
                Id = "ManageWork",
                Title = "Manage Your Work",
                ManageWorkImg = new() { ImageUrl = "/Images/managework.svg", AltText = "" },
                Link = new() { ActionName = "", ControllerName = "", Text = "Learn More" },
                ManageWorkLists = new List<ManageWorkList>
                {
                    new ManageWorkList { Icon = "/Images/bx-check-circle.svg", Text = "Powerful project management" },
                    new ManageWorkList { Icon = "/Images/bx-check-circle.svg", Text = "Transparent work management" },
                    new ManageWorkList { Icon = "/Images/bx-check-circle.svg", Text = "Manage work & focus on the most important tasks" },
                    new ManageWorkList { Icon = "/Images/bx-check-circle.svg", Text = "Track your progress with interactive charts" },
                    new ManageWorkList { Icon = "/Images/bx-check-circle.svg", Text = "Easiest way to track time spent on tasks" },
                }
            },

            App = new AppViewModel()
            {
                Id = "App",
                Image = new() { ImageUrl = "/Images/App.svg", AltText = "" },
                Title = "Download Our App for Any Devices:",
                Apps = new List<AppRating>
                {
                    new AppRating { Name="App Store", Rating="rating 4.7, 187K+ reviews", Award="Editor's Choice", AppLink = new(){ ImageUrl="/Images/appstore.svg", AltText="App store" }, LinkToStore="", },
                    new AppRating { Name="Google Play", Rating="rating 4.8, 30K+ reviews", Award="App of the Day", AppLink = new(){ ImageUrl="/Images/googleplay.svg", AltText="Google Play" }, LinkToStore="" },
                }

            },

            Integrate = new IntegrateViewModel()
            {
                Id = "Integrate",
                Title = "Integrate Top Work Tools",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin volutpat mollis egestas. Nam luctus facilisis ultrices. Pellentesque volutpat ligula est. Mattis fermentum, at nec lacus.",
                WorkTools = new List<WorkTools>
                {
                    new WorkTools { logoUrl ="/Images/Google.svg", text = "Lorem magnis pretium sed curabitur nunc facilisi nunc cursus sagittis."},
                    new WorkTools { logoUrl ="/Images/zoom.svg", text = "In eget a mauris quis. Tortor dui tempus quis integer est sit natoque placerat dolor."},
                    new WorkTools { logoUrl ="/Images/slack.svg", text = "Id mollis consectetur congue egestas egestas suspendisse blandit justo."},
                    new WorkTools { logoUrl ="/Images/gmail.svg", text = "Rutrum interdum tortor, sed at nulla. A cursus bibendum elit purus cras praesent."},
                    new WorkTools { logoUrl ="/Images/trello.svg", text = "Congue pellentesque amet, viverra curabitur quam diam scelerisque fermentum urna."},
                    new WorkTools { logoUrl ="/Images/mailchimp.svg", text = "A elementum, imperdiet enim, pretium etiam facilisi in aenean quam mauris."},
                    new WorkTools { logoUrl ="/Images/dropbox.svg", text = "Ut in turpis consequat odio diam lectus elementum. Est faucibus blandit platea."},
                    new WorkTools { logoUrl ="/Images/evernote.svg", text = "Faucibus cursus maecenas lorem cursus nibh. Sociis sit risus id. Sit facilisis dolor arcu."}
                }
            }



        };


        return View(viewModel);
    }

    [Route("/error")]
    public IActionResult Error(int statusCode)
    {
        return View();
    }

}

