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
                StudentCourses = student.StudentCourses?.Select(sc => sc.ToStudentCourseDto()).ToList()
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


    }
}