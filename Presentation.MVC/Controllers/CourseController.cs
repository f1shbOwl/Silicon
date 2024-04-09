using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Presentation.MVC.ViewModels.Views;
using System.Text;

namespace Presentation.MVC.Controllers;

public class CourseController : Controller
{
    public IActionResult Index()
    {
        return View();

    }

    public IActionResult Create()
    {
        return View();
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






    [HttpGet]
    [Route("/courses")]
    public async Task<IActionResult> Courses()
    {
        using var http = new HttpClient();
        var response = await http.GetAsync("https://localhost:7143/api/courses");
        var json = await response.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<IEnumerable<CourseEntity>>(json);

        return View(data);
    }

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
