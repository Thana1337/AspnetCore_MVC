
using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Infrastructure.Services;

public class AddressService
{
    private readonly AddressRepository _repository;
    private readonly ApplicationDbContext _context;

    public AddressService(AddressRepository repository, ApplicationDbContext context)
    {
        _repository = repository;
        _context = context;
    }

    public async Task<ResponsResult> GetOrCreateAddressAsync(string addressLine1, string? addressLine2, string postalCode, string city, string userId)
    {
        try
        {
            // Attempt to retrieve the address from the repository
            var addressEntity = await GetAddressAsync(userId);

            // If the address does not exist, create a new one
            if (addressEntity == null)
            {
                var createResult = await CreateAddressAsync(addressLine1, addressLine2, postalCode, city, userId);
                return createResult;
            }
            // Return the existing address
            return ResponseFactory.Ok(addressEntity, "Address already exists.");
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }

    public async Task<ResponsResult> CreateAddressAsync(string addressLine1, string? addressLine2, string postalCode, string city, string userId)
    {
        try
        {
            // Check if the address already exists
            var existingAddress = await GetAddressAsync(userId);
           

            // If the address does not exist, create it
            if (existingAddress == null)
            {
                var addressEntity = AddressFactory.Create(addressLine1, addressLine2, postalCode, city);
                addressEntity.UserId = userId;

                var result = await _repository.CreateOneAsync(addressEntity);

                // Check if the creation was successful
                if (result.StatusCode == StatusCode.OK)
                {
                    // Return the newly created address
                    return ResponseFactory.Ok(addressEntity);
                }
                else
                {
                    // Return the result from the repository if creation failed
                    return result;
                }
            }
            else
            {
                // Address already exists for the user
                return ResponseFactory.Exist("Address already exists for the user.");
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions and return an error response
            return ResponseFactory.Error(ex.Message);
        }
    }


    public async Task<AddressEntity?> GetAddressAsync(string userId)
    {
        try
        {
            var addressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.UserId == userId);
            return addressEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ERROR :: " + ex.Message);
            return null;
        }
    }

    public async Task<bool> UpdateAddressAsync(AddressEntity entity)
    {
        try
        {
            var existing = await _repository.GetByIdAsync(entity.Id);
            if (existing != null)
            {
                // Update the properties of the existing address entity
                existing.Addressline_1 = entity.Addressline_1;
                existing.Addressline_2 = entity.Addressline_2;
                existing.PostalCode = entity.PostalCode;
                existing.City = entity.City;

                await _repository.UpdateAsync(existing);
                await _repository.SaveChangesAsync();

                return true;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ERROR :: " + ex.Message);
        }

        return false;
    }
}




