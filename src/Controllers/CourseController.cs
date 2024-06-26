
using api.Dtos.Course;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.src.Dtos;
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
        public async Task<ApiListResDto<CourseDto>> Get([FromQuery] CourseQueryObject query){
            var courses = await _courseRepo.Get(query);
            var coursesDto = courses.Select(c => c.ToCourseDto()).ToList();

            return new ApiListResDto<CourseDto>(coursesDto, query.SkipCount,query.MaxResultCount);
        }

        [HttpGet("{id:int}")]
        public async Task<ApiResDto<CourseDto>> GetById(int id)
        {
            var course = await _courseRepo.GetById(id);
            if(course==null)
                return new ApiResDto<CourseDto>("not found");
            return new ApiResDto<CourseDto>(course.ToCourseDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool isDeleted = await _courseRepo.Delete(id);
            if(!isDeleted)
                return NotFound();
            return NoContent();
        }

        [HttpPost]
        public async Task<ApiResDto<CourseDto>> Create([FromBody] CreateCourseDto createCourseDto)
        {
            if(!ModelState.IsValid)
                return new ApiResDto<CourseDto>("body not found");

            var createdCourse = await _courseRepo.Create(createCourseDto);

            if(createdCourse == null)
                return new ApiResDto<CourseDto>("bad request");

            var result = await _courseRepo.GetById(createdCourse.Id);
            
            return new ApiResDto<CourseDto>(result.ToCourseDto());
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCourseDto updateCourseDto)
        {
            
            var updatedCourse = await _courseRepo.Update(id,updateCourseDto);
            if(updatedCourse == null)
                return NotFound();
            return Ok(updatedCourse.ToCourseDto());
        }
    }
}