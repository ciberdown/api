namespace api.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; } = "Ok";
        
        public List<StudentCourse>? StudentCourses { get; set;}
    }
}