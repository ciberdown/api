using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Student
{
    public class UpdateStudentDto
    {
        public string? Name { get; set; }
        public string? Status { get; set; }
    }
}