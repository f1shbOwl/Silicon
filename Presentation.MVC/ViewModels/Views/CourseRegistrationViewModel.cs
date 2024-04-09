using Infrastructure.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Presentation.MVC.ViewModels.Views;

public class CourseRegistrationViewModel
{
    [Required]
    [Display(Name = "Title")]
    public string Title { get; set; } = null!;

    [Display(Name = "Price")]
    public string? Price { get; set; }

    [Display(Name = "Discount Price")]
    public string? DiscountPrice { get; set; }

    [Display(Name = "Hours")]
    public string? Hours { get; set; }

    [Display(Name = "Is A Best Seller")]
    public bool IsBestSeller { get; set; } = false;

    [Display(Name = "Likes In Numbers")]
    public string? LikesInNumbers { get; set; }

    [Display(Name = "Likes In Procent")]
    public string? LikesInProcent { get; set; }

    [Display(Name = "Author(s)")]
    public string? Author { get; set; }
}
