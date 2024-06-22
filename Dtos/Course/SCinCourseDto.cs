using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Student;

namespace api.Dtos.Course
{
    public class SCinCourseDto
    {
        public int StudentId { get; set; }
        public StudentInCourseDto Student { get; set; }
        [Range(0,20)]
        public int? grade { get; set; }
    }
}