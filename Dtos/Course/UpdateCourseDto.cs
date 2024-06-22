using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Course
{
    public class UpdateCourseDto
    {
        public string? CourseName { get; set; }
        public string? Description { get; set; }
    }
}