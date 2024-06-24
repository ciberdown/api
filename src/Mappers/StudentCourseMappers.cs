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
                Id = sc.Course.Id,
                Name = sc.Course.CourseName,
                Description = sc.Course.Description,
                Grade = sc.Grade
            };
        }
        public static StudentCourse ToStudentCourse(this CreateScDto scCreate){
            return new StudentCourse
            {
                StudentId = scCreate.StudentId,
                CourseId = scCreate.CourseId,
                Grade = scCreate.Grade
            };
        }
    }
}