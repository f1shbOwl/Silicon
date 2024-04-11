using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Migrations;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(DataContext context) : ControllerBase
{
    private readonly DataContext _context = context;


    #region Get One Course

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _context.Courses.ToListAsync());

    #endregion


    #region Get All courses
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
        if (course != null)
        {
            return Ok(course);
        }

        return NotFound();
    }
    #endregion


    #region Create
    [HttpPost]
    public async Task<IActionResult> CreateOne(CourseRegistration form)
    {
        if (ModelState.IsValid)
        {
            var courseEntity = new CourseEntity
            {
                Title = form.Title,
                Price = form.Price,
                DiscountPrice = form.DiscountPrice,
                Hours = form.Hours,
                IsBestSeller = form.IsBestSeller,
                LikesInNumbers = form.LikesInNumbers,
                LikesInProcent = form.LikesInProcent,
                Author = form.Author,
                Image = form.Image
            };


            _context.Courses.Add(courseEntity);
            await _context.SaveChangesAsync();

            return Created("", (Course)courseEntity);

        }
        return BadRequest();
    }
    #endregion


    #region DeleteOne

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOne(int id)
    {

        if (ModelState.IsValid)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();

                return Ok();
            }
            return NotFound();
        }
        return BadRequest();
    }
    #endregion

}
