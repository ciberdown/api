using api.Dtos.Course;

namespace api.Dtos.StudentCourse
{
    public class StudentCoursesInStudentDto
    {
        public CourseInStudentDto Course{ get; set; }
        public int? grade { get; set; }
    }
}