using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services;

public class AccountService
{
    private readonly DataContext _dataContext;
    private readonly UserManager<UserEntity> _userManager;

    public AccountService(DataContext dataContext, UserManager<UserEntity> userManager)
    {
        _dataContext = dataContext;
        _userManager = userManager;
    }


    //public async Task<bool> UpdateUserAsync(UserEntity user)
    //{
    //    _dataContext
    //}
}
