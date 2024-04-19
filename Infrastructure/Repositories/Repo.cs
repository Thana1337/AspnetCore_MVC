
using Infrastructure.Context;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public abstract class Repo<TEntity>(ApplicationDbContext context) where TEntity : class
{
    private readonly ApplicationDbContext _context = context;


    //SOLID : Single Responsibility Principle
    public virtual async Task<ResponsResult> CreateOneAsync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return ResponseFactory.Ok(entity);
        }
        catch (Exception ex) 
        {
            return ResponseFactory.Error(ex.Message);
        }

    }

    public virtual async Task<ResponsResult> GetAllAsync()
    {
        try
        {
            IEnumerable<TEntity> result = await _context.Set<TEntity>().ToListAsync();
            if (result == null)
                return ResponseFactory.NotFound();

            return ResponseFactory.Ok(result);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }

    }
    //x => x.Id == id
    public virtual async Task<ResponsResult> GetOneAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (result == null)
                return ResponseFactory.NotFound();

            return ResponseFactory.Ok(result);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }

    }


    public virtual async Task<ResponsResult> UpdateOneAsync(Expression<Func<TEntity, bool>> predicate, TEntity updatedEntity)
    {
        try
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
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

    public virtual async Task<ResponsResult> DeleteOneAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (result != null)
            {
                _context.Set<TEntity>().Remove(result);
                await _context.SaveChangesAsync();
                return ResponseFactory.Ok("Removed");
            }


            return ResponseFactory.NotFound();

        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }

    }

    public virtual async Task<ResponsResult> AlreadyExistAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<TEntity>().AnyAsync(predicate);
            if (result)
            {
                return ResponseFactory.Exist();
            }


            return ResponseFactory.NotFound();

        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }

    }


}
