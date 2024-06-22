using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Course
{
    public class CreateCourseDto
    {
        [MinLength(5)]
        [MaxLength(50)]
        public string CourseName { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}