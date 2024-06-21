using api.Dtos.Course;
using api.Models;

namespace api.Mappers
{
    public static class CourseMappers
    {
        public static CourseDto ToCourseDto(this Course course){
            return new CourseDto
            {
                Id = course.Id,
                CourseName = course.CourseName,
                Description = course.Description
            };
        }
    }
}