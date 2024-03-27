using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AddressManager(DataContext context)
{
    private readonly DataContext _context = context;


    public async Task<AddressEntity> GetAddressAsync(string userId)
    {
        var addressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.UserId == userId);
        return addressEntity!;
    }

    public async Task<bool> CreateAddressAsync(AddressEntity entity)
    {
        _context.Addresses.Add(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAddressAsync(AddressEntity entity)
    {
        var exist = await _context.Addresses.FirstOrDefaultAsync(x => x.UserId == entity.UserId);
        if (exist != null)
        {
            _context.Entry(exist).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();

            return true;
        }
        return false;
    }
}
