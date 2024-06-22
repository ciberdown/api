using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.StudentCoures
{
    public class StudentCourseDto
    {
        public int StudentId { get; set; }
        public Models.Student Student { get; set; }

        public int CourseId { get; set; }
        public Models.Course Course{ get; set; }
        public int? grade { get; set; }
    }
}