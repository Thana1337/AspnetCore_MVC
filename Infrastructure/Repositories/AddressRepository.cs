
using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class AddressRepository(ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;

    public async Task<ResponsResult> CreateOneAsync(AddressEntity entity)
    {
        try
        {
            await _context.Addresses.AddAsync(entity);
            return ResponseFactory.Ok();
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }

    public async Task<bool> SaveChangesAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    public async Task<ResponsResult> GetOneAsync(Expression<Func<AddressEntity, bool>> predicate)
    {
        try
        {
            var entity = await _context.Addresses.FirstOrDefaultAsync(predicate);
            return entity != null ? ResponseFactory.Ok(entity) : ResponseFactory.NotFound();
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }

    public async Task<ResponsResult> UpdateAsync(AddressEntity entity)
    {
        try
        {
            var existingEntity = await _context.Addresses.FindAsync(entity.Id);
            if (existingEntity == null)
            {
                return ResponseFactory.NotFound();
            }

            existingEntity.Addressline_1 = entity.Addressline_1;
            existingEntity.Addressline_2 = entity.Addressline_2;
            existingEntity.PostalCode = entity.PostalCode;
            existingEntity.City = entity.City;

            _context.Addresses.Update(existingEntity);
            await _context.SaveChangesAsync();

            return ResponseFactory.Ok();
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }

    public async Task<AddressEntity> GetByIdAsync(int id)
    {
        try
        {
            return await _context.Addresses.FindAsync(id);
        }
        catch (Exception ex)
        {
            // Handle any exceptions
            Console.WriteLine($"Error occurred while getting address by Id: {ex.Message}");
            throw;
        }
    }

}


