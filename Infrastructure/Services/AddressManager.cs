using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AddressManager(DataContext context)
{
    private readonly DataContext _context = context;


    public async Task<AddressEntity> GetAddressAsync(int Id)
    {
        try
        {
            var addressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == Id);
            return addressEntity!;
        }
        catch (Exception)
        {

            throw;
        }
    }


    public async Task<int> GetOrCreateAddressAsync(string addressLine1, string? addressLine2, string postalCode, string city)
    {
        var existsAddress = await _context.Addresses.FirstOrDefaultAsync(x => x.AddressLine_1 == addressLine1 &&  x.AddressLine_2 == addressLine2 && x.PostalCode == postalCode && x.City == city);
        if (existsAddress != null)
        {
            return existsAddress.Id;
        }
        else
        {
            var newAddress = new AddressEntity
            {
                AddressLine_1 = addressLine1,
                AddressLine_2 = addressLine2,
                PostalCode = postalCode,
                City = city
            };

            _context.Addresses.Add(newAddress);
             await _context.SaveChangesAsync();
            return newAddress.Id;
        }
    }

    public async Task<bool> CreateAddressAsync(AddressEntity entity)
    {
        _context.Addresses.Add(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAddressAsync(AddressEntity entity)
    {
        var exist = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == entity.Id);
        if (exist != null)
        {
            _context.Entry(exist).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();

            return true;
        }
        return false;
    }
}
