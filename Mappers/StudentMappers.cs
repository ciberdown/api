using api.Dtos.Course;
using api.Dtos.Student;
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
                StudentCourses = student.StudentCourses?.Select(sc => sc.ToStudentCourseDto()).ToList().ToStandardRes()
            };
        }

        public static Student ToCreateStudentDto(this CreateStudentDto createStudentDto)
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