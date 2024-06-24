using api.Dtos.Course;

namespace api.Dtos.StudentCourse
{
    public class StudentCoursesInStudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Grade { get; set; }
    }
}