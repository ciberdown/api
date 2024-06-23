using System.ComponentModel.DataAnnotations;
using api.Dtos.Student;

namespace api.Dtos.Course
{
    public class SCinCourseDto
    {
        public int StudentId { get; set; }
        public StudentInCourseDto Student { get; set; }
        [Range(0,20)]
        public int? Grade { get; set; }
    }
}