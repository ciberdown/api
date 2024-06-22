
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepo _courseRepo;

        public CourseController(ICourseRepo courseRepo)
        {
            _courseRepo = courseRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CourseQueryObject query){
            var courses =await _courseRepo.Get(query);
            var coursesDto = courses.Select(c => c.ToCourseDto()).ToList();

            return Ok(coursesDto.ToStandardRes());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _courseRepo.GetById(id);
            if(course==null)
                return NotFound();
            return Ok(course.ToCourseDto());
        }

    }
}