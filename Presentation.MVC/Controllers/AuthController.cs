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



    /// <summary>
    /// Sign up
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Sign in
    /// </summary>
    /// <returns></returns>
    [Route("/signin")]
    [HttpGet]
    public IActionResult SignIn()
    {
        var viewModel = new SignInViewModel();
        return View(viewModel);
    }

    [Route("/signin")]
    [HttpPost]
    public IActionResult SignIn(SignInViewModel viewModel)
    {

        if (!ModelState.IsValid)
            return View(viewModel);

        //var result = _authService.SignIn(viewmModel.Form);
        //if (result)
        //    return RedirectToAction("Account", "Index");

        viewModel.ErrorMessage = "Incorrect email or password";
        return View(viewModel);

        
    }




    /// <summary>
    /// Sign out
    /// </summary>
    /// <returns></returns>
    public new IActionResult SignOut()
    {
        return RedirectToAction("Index", "Home");
    }
    
}
