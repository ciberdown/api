using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Student
{
    public class CreateStudentDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}