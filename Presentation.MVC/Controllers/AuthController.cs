using Microsoft.AspNetCore.Mvc;

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
    public IActionResult SignUp()
    {
        return View();
    }

    public new IActionResult SignOut()
    {
        return RedirectToAction("Index", "Home");
    }
}
