
using api.Dtos.StudentCourse;

namespace api.Dtos.Student
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; } = "Ok";
        
        public StandardResDto<StudentCoursesDto> StudentCourses { get; set;}
    }
}