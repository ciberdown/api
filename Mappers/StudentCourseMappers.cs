using api.Dtos.StudentCoures;
using api.Dtos.StudentCourse;
using api.Models;

namespace api.Mappers
{
    public static class StudentCourseMappers
    {
        public static StudentCourseDto ToSCDto(this StudentCourse sc){
            return new StudentCourseDto{
                StudentId = sc.StudentId,
                Name = sc.Student.Name,
                StudentStatus = sc.Student.Status,
                CourseId = sc.CourseId,
                CourseName = sc.Course.CourseName,
                CourseDescription = sc.Course.Description,
                Grade = sc.Grade,
            };
        }
        public static StudentCoursesInStudentDto ToStudentCourseDto(this StudentCourse sc){
            return new StudentCoursesInStudentDto
            {   
                Course = sc.Course.ToCourseInStudentDto(),
                Grade = sc.Grade
            };
        }
    }
}