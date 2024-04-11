using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Presentation.MVC.ViewModels.Views;
using System.Text;

namespace Presentation.MVC.Controllers;

[Authorize]

public class CoursesController(HttpClient httpClient) : Controller
{

    private readonly HttpClient _httpClient = httpClient;


    [Route("/courses")]
    public async Task <IActionResult> Index()
    {

        var viewModel = new CourseIndexViewModel();

        var response = await _httpClient.GetAsync("https://localhost:7143/api/courses");
        if (response.IsSuccessStatusCode)
        {
            var courses = JsonConvert.DeserializeObject<IEnumerable<CourseViewModel>>(await response.Content.ReadAsStringAsync());
            if (courses != null && courses.Any())
                viewModel.Courses = courses;
        }

        return View(viewModel);

    }


    [Route("/SuperSecretAdminTool/AddCourses")]
    public async Task<IActionResult> Create(CourseRegistrationViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            using var http = new HttpClient();
            var json = JsonConvert.SerializeObject(viewModel);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await http.PostAsync($"https://localhost:7143/api/courses", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Courses");
            }
        }

        return View(viewModel);
    }

    //[HttpGet]
    //[Route("/courses")]
    //public async Task<IActionResult> Courses()
    //{
    //    using var http = new HttpClient();
    //    var response = await http.GetAsync("https://localhost:7143/api/courses");
    //    var json = await response.Content.ReadAsStringAsync();
    //    var data = JsonConvert.DeserializeObject<IEnumerable<CourseEntity>>(json);

    //    return View(data);
    //}

    [HttpGet]
    [Route("/courses/SingleCourse")]
    public async Task<IActionResult> Details()
    {
        using var http = new HttpClient();
        var response = await http.GetAsync("https://localhost:7143/api/courses/1");
        var json = await response.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<CourseEntity>(json);

        return View(data);
    }

}
