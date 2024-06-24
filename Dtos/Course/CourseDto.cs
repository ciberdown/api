using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Course
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? StartDate { get; set; }
        
        public StandardResDto<SCinCourseDto>? Students{ get; set; }
    }
}