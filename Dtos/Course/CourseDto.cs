namespace api.Dtos.Course
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string? Description { get; set; }
        
        public StandardResDto<SCinCourseDto>? StudentCourses{ get; set; }
    }
}