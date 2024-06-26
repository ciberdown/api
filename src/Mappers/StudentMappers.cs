using api.Dtos;
using api.Dtos.Course;
using api.Dtos.Student;
using api.Helpers;
using api.Models;

namespace api.Mappers
{
    public static class StudentMappers
    {
        public readonly static string DefaultStatus = "Ok";
        public static StudentDto ToStudentDto(this Student student)
        {
            return new StudentDto{
                Id = student.Id,
                Name = student.Name, 
                Status = student.Status,
                Courses = student.StudentCourses?.Select(sc => sc.ToStudentCourseDto()).ToList().ToCountedResDto(),
            };
        }

        public static Student ToStudent(this CreateStudentDto createStudentDto)
        {
            return new Student
            {
                Name = createStudentDto.Name,
                Status = DefaultStatus
            };
        }


        public static CourseInStudentDto ToCourseInStudentDto(this Course course){
            return new CourseInStudentDto
            {
                Id = course.Id,
                CourseName = course.CourseName,
                Description = course.Description
            };
        }
    }
}