using AspnetCore_MVC.Models;
using AspnetCore_MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AspnetCore_MVC.Controllers;

[Authorize]
public class CourseController(HttpClient http) : Controller
{
    private readonly HttpClient _http = http;

    [Route("/courses")]
    public async Task<IActionResult> Index()
    {
        var viewModel = new CourseViewModel();
        var response = await _http.GetAsync("https://localhost:7121/api/course");
        var jason = await response.Content.ReadAsStringAsync();

        viewModel.Courses = JsonConvert.DeserializeObject<IEnumerable<CourseModel>>(jason)!;

        return View(viewModel);
    }
}
