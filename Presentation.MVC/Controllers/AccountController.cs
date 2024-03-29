using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.MVC.ViewModels.Account;
using Presentation.MVC.ViewModels.Sections;

namespace Presentation.MVC.Controllers;

[Authorize]
public class AccountController(SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager, AddressManager addressManager) : Controller
{

    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly AddressManager _addressManager = addressManager;



    #region Account Details
    [HttpGet]
    [Route("/account/details")]
    public async Task<IActionResult> Details()
    {
        var viewModel = new AccountDetailsViewModel
        {
            ProfileInfo = await PopulateProfileInfoAsync()
        };
        viewModel.BasicInfo ??= await PopulateBasicInfoAsync();
        viewModel.AddressInfo ??= await PopulateAddressInfoAsync();
        return View(viewModel);
    }
    #endregion



    #region Http Post Account Details
    [HttpPost]
    [Route("/account/details")]
    public async Task<IActionResult> Details(AccountDetailsViewModel viewModel)
    {
        if (viewModel.BasicInfo != null)
        {
            if (viewModel.BasicInfo.FirstName != null && viewModel.BasicInfo.LastName != null && viewModel.BasicInfo.Email != null)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    user.FirstName = viewModel.BasicInfo.FirstName;
                    user.LastName = viewModel.BasicInfo.LastName;
                    user.Email = viewModel.BasicInfo.Email;
                    user.PhoneNumber = viewModel.BasicInfo.Phone;
                    user.Bio = viewModel.BasicInfo.Biography;

                    var result = await _userManager.UpdateAsync(user);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("Error, data not saved", "Unable to save data");
                        ViewData["ErrorMessage"] = "Unable to save data";
                    }
                }
            }
        }

        if (viewModel.AddressInfo != null)
        {
            if (viewModel.AddressInfo.AddressLine_1 != null && viewModel.AddressInfo.PostalCode != null && viewModel.AddressInfo.City != null)
            {
                var addressId = await _addressManager.GetOrCreateAddressAsync(viewModel.AddressInfo.AddressLine_1, viewModel.AddressInfo.AddressLine_2, viewModel.AddressInfo.PostalCode, viewModel.AddressInfo.City);

                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {

                    user.AddressId = addressId;

                    await _userManager.UpdateAsync(user);
                }
            }
        }
        viewModel.ProfileInfo = await PopulateProfileInfoAsync();
        viewModel.BasicInfo ??= await PopulateBasicInfoAsync();
        viewModel.AddressInfo ??= await PopulateAddressInfoAsync();

        return View(viewModel);
    }
    #endregion





    #region Save Basic Info
    [HttpPost]
    public IActionResult SaveBasicInfo(AccountDetailsViewModel viewModel)
    {
        if (TryValidateModel(viewModel.BasicInfo))
        {
            return RedirectToAction("Index", "Home");
        }
        return View("Details", viewModel);
    }
    #endregion

    #region Save Address Info
    [HttpPost]
    public IActionResult SaveAddressInfo(AccountDetailsViewModel viewModel)
    {
        if (TryValidateModel(viewModel.AddressInfo))
        {
            return RedirectToAction("Index", "Home");
        }
        return View("Details", viewModel);
    }
    #endregion




    #region Populate Profile Info
    private async Task<ProfileInfoViewModel> PopulateProfileInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);

        return new ProfileInfoViewModel
        {
            FirstName = user!.FirstName,
            LastName = user.LastName,
            Email = user.Email!,
        };
    }
    #endregion


    #region Populate Basic Info
    private async Task<BasicInfoViewModel> PopulateBasicInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);

        return new BasicInfoViewModel
        {
            FirstName = user!.FirstName,
            LastName = user.LastName,
            Email = user.Email!,
            Phone = user.PhoneNumber,
            Biography = user.Bio,
        };
    }
    #endregion




    #region Populate Address Info
    private async Task<AddressInfoViewModel> PopulateAddressInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user != null && user.AddressId != null)
        {
            var address = await _addressManager.GetAddressAsync(user.AddressId.Value);
            if (address != null)
            {
                return new AddressInfoViewModel
                {
                    Id = user.AddressId,
                    AddressLine_1 = address.AddressLine_1,
                    AddressLine_2 = address.AddressLine_2,
                    PostalCode = address.PostalCode,
                    City = address.City,
                };
            }
        }
        return new AddressInfoViewModel();
    }
    #endregion




    //#region Populate Address Info
    //private async Task<AddressInfoViewModel> PopulateAddressInfoAsync()
    //{
    //    var user = await _userManager.GetUserAsync(User);
    //    if (user != null)
    //    {
    //        var address = await _addressManager.GetAddressAsync(user.AddressId);
    //        return new AddressInfoViewModel
    //        {
    //            AddressLine_1 = address.AddressLine_1,
    //            AddressLine_2 = address.AddressLine_2,
    //            PostalCode = address.PostalCode,
    //            City = address.City,
    //        };
    //    }
    //    return new AddressInfoViewModel();
    //}
    //#endregion

}
