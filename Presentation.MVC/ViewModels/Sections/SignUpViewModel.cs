using Presentation.MVC.Models;

namespace Presentation.MVC.ViewModels.Sections;

public class SignUpViewModel
{
    public string Title { get; set; } = "Sign up";
    public SignUpModel Form { get; set; } = new SignUpModel();
    
}
