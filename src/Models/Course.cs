namespace api.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string? Description { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? StartDate { get; set; }
        
        public List<StudentCourse>? StudentCourses{ get; set; }
    }
}