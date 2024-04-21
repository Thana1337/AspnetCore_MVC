using Infrastructure.Context;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        #region Create

        [HttpPost]
        public async Task<IActionResult> Create(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                if (!await _context.Subscribers.AnyAsync(x => x.Email == email))
                {
                    try
                    {
                        var subscribeEntity = new SubscribeEntity { Email = email };
                        _context.Subscribers.Add(subscribeEntity);
                        await _context.SaveChangesAsync();
                        return Created("", null);
                    }

                    catch
                    {
                        return Problem("Unable to subscribe");
                    }
                }
                return Conflict("You are already subscribed");
            }
            return BadRequest("Invalid Email");
        }

        #endregion

        #region Read

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var subscribers = await _context.Subscribers.ToListAsync();
            if (subscribers.Count != 0)
            {
                return Ok(subscribers);
            }
            return NotFound();

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Id == id);
            if (subscriber != null)
            {
                return Ok(subscriber);
            }
            return NotFound();
        }
        #endregion

        #region Update

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateOne(int id, string email)
        {
            var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Id == id);
            if (subscriber != null)
            {
                subscriber.Email = email;
                _context.Subscribers.Update(subscriber);
                await _context.SaveChangesAsync();

                return Ok(subscriber);
            }
            return NotFound();

        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteOne(int id)
        {
            var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Id == id);
            if (subscriber != null)
            {
                _context.Subscribers.Remove(subscriber);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return NotFound();

        }
        #endregion
    }
}
