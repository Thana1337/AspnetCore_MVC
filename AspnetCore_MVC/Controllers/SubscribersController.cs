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
            return View(new SubsribedViewModel());
        }


        [HttpPost]
        [Route("/subscribe")]
        public async Task<IActionResult> Index(SubsribedViewModel viewModel)
        {
            if (ModelState.IsValid)
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
                    ModelState.AddModelError("", "Email is already subscribed.");
                    return View(viewModel); 
                }
            }
            return View(viewModel);
        }
    }
}
