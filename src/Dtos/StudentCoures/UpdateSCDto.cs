using System.ComponentModel.DataAnnotations;

namespace api.Dtos.StudentCoures
{
    public class UpdateSCDto
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        [Range(0, 20)]
        public int Grade { get; set; }
    }
}