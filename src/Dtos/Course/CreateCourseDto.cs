using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Course
{
    public class CreateCourseDto
    {
        [MinLength(5)]
        [MaxLength(50)]
        public string CourseName { get; set; }

        public DateTime? StartDate { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}