using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Course
{
    public class CourseInStudentDto
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string? Description { get; set; }
    }
}