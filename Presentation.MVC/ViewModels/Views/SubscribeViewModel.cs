﻿using System.ComponentModel.DataAnnotations;

namespace Presentation.MVC.ViewModels.Views;

public class SubscribeViewModel
{
    [Required]
    [EmailAddress]
    [Display(Name = "Subscribe", Prompt="Your Email")]
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
