using System.ComponentModel.DataAnnotations;
using api.Dtos.Student;

namespace api.Dtos.Course
{
    public class SCinCourseDto
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Status { get; set; }
        [Range(0,20)]
        public int? Grade { get; set; }
    }
}