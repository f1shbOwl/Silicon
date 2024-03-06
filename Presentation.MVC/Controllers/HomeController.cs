using Microsoft.AspNetCore.Mvc;
using Presentation.MVC.Models.Views;

namespace Presentation.MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {

        var viewModel = new HomeIndexViewModel();
        ViewData["Title"] = viewModel.Title;

        return View(viewModel);
        
    }
}
