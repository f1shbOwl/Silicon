using Infrastructure.Contexts;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public abstract class Repo<TENtity>(DataContext context) where TENtity : class
{
    private readonly DataContext _context = context;

    public virtual async Task<ResponseResult> CreateAsync(TENtity entity)
    {
        try
        {
            _context.Set<TENtity>().Add(entity);
            await _context.SaveChangesAsync();
            return ResponseFactory.Ok(entity);
        }
        catch (Exception ex) 
        {
            return ResponseFactory.Error(ex.Message);
        }
    }


    public virtual async Task<ResponseResult> GetAllAsync()
    {
        try
        {
            IEnumerable<TENtity> result = await _context.Set<TENtity>().ToListAsync();
            return ResponseFactory.Ok(result);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }


    public virtual async Task<ResponseResult> GetOneAsync(Expression<Func<TENtity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<TENtity>().FirstOrDefaultAsync(predicate);
            if (result == null)
                return ResponseFactory.NotFound();

            return ResponseFactory.Ok(result);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }


    public virtual async Task<ResponseResult> UpdateOneAsync(Expression<Func<TENtity, bool>> predicate, TENtity updatedEntity)
    {
        try
        {
            var result = await _context.Set<TENtity>().FirstOrDefaultAsync(predicate);
            if (result != null)
            {
                _context.Entry(result).CurrentValues.SetValues(updatedEntity);
                await _context.SaveChangesAsync();
                return ResponseFactory.Ok(result);
            }
            return ResponseFactory.NotFound();
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }


    public virtual async Task<ResponseResult> DeleteOneAsync(Expression<Func<TENtity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<TENtity>().FirstOrDefaultAsync(predicate);
            if (result != null)
            {
                _context.Set<TENtity>().Remove(result);
                await _context.SaveChangesAsync();
                return ResponseFactory.Ok("Successfully removed");
            }
            return ResponseFactory.NotFound();
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }


    public virtual async Task<ResponseResult> AlreadyExistsAsync(Expression<Func<TENtity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<TENtity>().AnyAsync(predicate);
            if (result)
                return ResponseFactory.Exists();

            return ResponseFactory.NotFound();
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }
}
