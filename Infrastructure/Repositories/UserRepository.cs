
using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context) : Repo<UserEntity>(context)
{

    private readonly ApplicationDbContext _context = context;

    public override async Task<ResponsResult> GetAllAsync()
    {
        try
        {
            IEnumerable<UserEntity> result = await _context.Users
                .Include(i => i.Addresses)
                .ToListAsync();

            if (result == null)
                return ResponseFactory.NotFound();

            return ResponseFactory.Ok(result);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }

    public override async Task<ResponsResult> GetOneAsync(Expression<Func<UserEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Users
                .Include(i => i.Addresses)
                .FirstOrDefaultAsync(predicate);
            if (result == null)
                return ResponseFactory.NotFound();

            return ResponseFactory.Ok(result);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }

    public async Task<ResponsResult> SaveAsync(UserEntity user)
    {
        try
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return ResponseFactory.Ok(user);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }

    public async Task<ResponsResult> UpdateAsync(UserEntity user)
    {
        try
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return ResponseFactory.Ok(user);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }
}
