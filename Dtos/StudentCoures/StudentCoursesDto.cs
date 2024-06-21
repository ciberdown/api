using api.Dtos.Course;

namespace api.Dtos.StudentCourse
{
    public class StudentCoursesDto
    {
        public CourseDto Course{ get; set; }
        public int? grade { get; set; }
    }
}