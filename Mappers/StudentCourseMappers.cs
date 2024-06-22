using api.Dtos.StudentCourse;
using api.Models;

namespace api.Mappers
{
    public static class StudentCourseMappers
    {
        public static StudentCoursesInStudentDto ToStudentCourseDto(this StudentCourse sc){
            return new StudentCoursesInStudentDto
            {   
                Course = sc.Course.ToCourseInStudentDto(),
                grade = sc.grade
            };
        }
    }
}