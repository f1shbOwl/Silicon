using Presentation.MVC.Models;

namespace Presentation.MVC.ViewModels.Sections;

public class AccountDetailsViewModel
{
    public string Title { get; set; } = "Account Details";
    public AccountDetailsBasicModel BasicInfo { get; set; } = new AccountDetailsBasicModel()
    {
        ProfileImage = "images/avatar.svg",
        FirstName = "Björn",
        LastName = "Lager Dalbratt",
        Email = "bjorn@domain.com"
    };
    public AccountDetailsAddressModel AddressInfo { get; set; } = new AccountDetailsAddressModel();
}
