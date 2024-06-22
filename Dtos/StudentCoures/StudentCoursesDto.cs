using api.Dtos.Course;

namespace api.Dtos.StudentCourse
{
    public class StudentCoursesDto
    {
        public CourseInStudentDto Course{ get; set; }
        public int? grade { get; set; }
    }
}