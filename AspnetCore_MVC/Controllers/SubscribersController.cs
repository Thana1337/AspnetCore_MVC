using AspnetCore_MVC.ViewModels;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace AspnetCore_MVC.Controllers
{
    public class SubscribersController : Controller
    {

        [HttpGet]
        [Route("/subscribe")]
        public IActionResult Index()
        {

            var viewModel = new HomeIndexViewModel
            {
                Subsribed = new SubsribedViewModel()
            };

            // Pass HomeIndexViewModel to the view
            return View(viewModel);
        }


        [HttpPost]
        [Route("/subscribe")]
        public async Task<IActionResult> Subscribe(SubsribedViewModel viewModel)
        {
            using var http = new HttpClient();

            var url = $"https://localhost:7121/api/subscribers?email={viewModel.Email}";
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await http.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                viewModel.IsSubbed = true;
            }
            else if (response.StatusCode == HttpStatusCode.Conflict)
            {
                viewModel.IsSubbed = false;
            }

            var updatedViewModel = new HomeIndexViewModel
            {
                Subsribed = viewModel
            };

            return View("Index", updatedViewModel);
        }
    }
}
