using Presentation.MVC.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Presentation.MVC.Models;

public class SignUpModel
{
    [DataType(DataType.Text)]
    [Display(Name = "First name", Prompt = "Enter your first name", Order = 0)]
    [Required(ErrorMessage = "Enter your first name")]
    [MinLength(2, ErrorMessage = "Enter your first name")]
    public string FirstName { get; set; } = null!;


    [DataType(DataType.Text)]
    [Display(Name = "Last name", Prompt = "Enter your last name", Order = 1)]
    [Required(ErrorMessage = "Enter your last name")]
    [MinLength(2, ErrorMessage = "Enter your last name")]
    public string LastName { get; set; } = null!;


    [Display(Name = "Email address", Prompt = "Enter your email address", Order = 2)]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email a valid email address")]
    [RegularExpression("^(([^<>()\\[\\]\\\\.,;:\\s@\"]+(\\.[^<>()\\[\\]\\\\.,;:\\s@\"]+)*)|(\".+\"))@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$", ErrorMessage = "Email a valid email address")]
    public string Email { get; set; } = null!;


    [Display(Name = "Password", Prompt = "Enter your password", Order = 3)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Enter a valid password")]
    [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Enter a valid password")]
    public string Password { get; set; } = null!;


    [Display(Name = "Confirm password", Prompt = "Confirm your passwrod", Order = 4)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password must be confirmed")]
    [Compare(nameof(Password), ErrorMessage = "Password must be confirmed")]
    public string ConfirmPassword { get; set; } = null!;


    [Display(Name = "I agree to Terms & Conditions ", Order = 5)]
    [CheckboxRequired(ErrorMessage = "You must accept terms and conditions to proceed")]
    public bool TermsAndCondition { get; set; } = false;

}

