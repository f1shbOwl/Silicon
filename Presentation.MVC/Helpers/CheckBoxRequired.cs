using System.ComponentModel.DataAnnotations;

namespace Presentation.MVC.Helpers;

public class CheckboxRequired : ValidationAttribute
{
    public override bool IsValid(object? value) => value is bool b && b;
}
