using System.ComponentModel.DataAnnotations;

namespace Presentation.MVC.ViewModels.Views;

public class SubscribeViewModel
{
    [EmailAddress]
    [Display(Name = "Subscribe", Prompt="Your Email")]
    [Required(ErrorMessage = "Enter a valid email address")]
    [RegularExpression("^(([^<>()\\[\\]\\\\.,;:\\s@\"]+(\\.[^<>()\\[\\]\\\\.,;:\\s@\"]+)*)|(\".+\"))@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$", ErrorMessage = "Email a valid email address")]
    public string Email { get; set; } = null!;

    [Display(Name = "Daily Newsletter")]
    public bool DailyNewsletter { get; set; }

    [Display(Name = "Advertising Updates")]
    public bool AdvertisingUpdates { get; set; }

    [Display(Name = "Week In Review")]
    public bool WeekInReview { get; set; }

    [Display(Name = "Event Updates")]
    public bool EventUpdates { get; set; }

    [Display(Name = "Startups Weekly")]
    public bool StartupsWeekly { get; set; }

    [Display(Name = "Podcasts")]
    public bool Podcasts {  get; set; }


}
