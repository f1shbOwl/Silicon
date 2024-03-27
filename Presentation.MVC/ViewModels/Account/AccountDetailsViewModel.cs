using Infrastructure.Entities;
using Presentation.MVC.ViewModels.Account;
using System.ComponentModel.DataAnnotations;

namespace Presentation.MVC.ViewModels.Sections;

public class AccountDetailsViewModel
{
    public ProfileInfoViewModel ProfileInfo { get; set; } = null!;
    public BasicInfoViewModel BasicInfo { get; set; } = null!;
    public AddressInfoViewModel AddressInfo { get; set; } = null!;

}
