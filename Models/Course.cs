using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string? Description { get; set; }
        
        public List<StudentCourse>? StudentCourses{ get; set; }
    }
}