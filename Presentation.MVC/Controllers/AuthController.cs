using Microsoft.AspNetCore.Mvc;
using Presentation.MVC.ViewModels.Sections;

namespace Presentation.MVC.Controllers;

public class AuthController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Profile";
        return View();
    }

    public IActionResult SignIn()
    {
        ViewData["Title"] = "Sign in";
        return View();
    }

    [Route("/signup")]
    [HttpGet]
    public IActionResult SignUp()
    {
        var viewModel = new SignUpViewModel();
        return View(viewModel);
    }

    [Route("/signup")]
    [HttpPost]
    public IActionResult SignUp(SignUpViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        return RedirectToAction("SignIn", "Auth");
    }

    public new IActionResult SignOut()
    {
        return RedirectToAction("Index", "Home");
    }
}
