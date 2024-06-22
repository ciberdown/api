namespace api.Dtos.Course
{
    public class CourseDto
    {
        public string CourseName { get; set; }
        public string? Description { get; set; }
        
        public StandardResDto<SCinCourseDto>? StudentCourses{ get; set; }
    }
}