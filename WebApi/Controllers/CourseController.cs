using Infrastructure.Context;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;


        [HttpPost]
        public async Task<IActionResult> CreateOne(CourseDto dto)
        {
            if (ModelState.IsValid)
            {
                if (await _context.Courses.AnyAsync(x => x.Title == dto.Title))
                {
                    var courseEntity = new CourseEntity
                    {
                        Title = dto.Title,
                        Author = dto.Author,
                        ImgUrl = dto.ImgUrl,
                        IsBestSeller = dto.IsBestSeller,
                        Price = dto.Price,
                        Discount = dto.Discount,
                        LikesInNumber = dto.LikesInNumber,
                        LikesInProcent = dto.LikesInProcent,
                        Hours = dto.Hours,

                    };
                    _context.Courses.Add(courseEntity);
                    await _context.SaveChangesAsync();

                    return Created("",null);

                }
                return Conflict();
            }

            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _context.Courses.ToListAsync();
            return Ok(courses);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(string id)
        {
            var coursesEntity = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if(coursesEntity != null)
            {
                return Ok(coursesEntity);
            }

            return NotFound();
        }
    }
}
