using api.Dtos.StudentCourse;
using api.Models;

namespace api.Mappers
{
    public static class StudentCourseMappers
    {
        public static StudentCoursesDto ToStudentCourseDto(this StudentCourse sc){
            return new StudentCoursesDto
            {   
                Course = sc.Course.ToCourseDto(),
                grade = sc.grade
            };
        }
    }
}