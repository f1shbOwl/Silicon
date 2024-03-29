﻿namespace Presentation.MVC.ViewModels.Sections;

public class ProfileInfoViewModel
{
    public string? ProfileImage { get; set; } = "~/images/avatar.svg";

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;
}
