using System.ComponentModel.DataAnnotations;

namespace api.Dtos.StudentCoures
{
    public class StudentCourseDto
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string StudentStatus { get; set; } = "Ok";
        [Required]
        public int CourseId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CourseName { get; set; }
        [Required]
        [MaxLength(500)]
        public string? CourseDescription { get; set; }
        [Range(0,20)]
        public int? Grade { get; set; }
    }
}