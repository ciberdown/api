
using api.Dtos.Course;
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool isDeleted = await _courseRepo.Delete(id);
            if(!isDeleted)
                return NotFound();
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCourseDto createCourseDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCourse = await _courseRepo.Create(createCourseDto);
            if(createdCourse == null)
                return BadRequest();
            return CreatedAtAction(nameof(Create), new {id = createdCourse.Id}, createdCourse);
        }
    }
}