using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Student
{
    public class UpdateStudentDto
    {
        [MinLength(5)]
        [MaxLength(50)]
        public string? Name { get; set; }
        
        [MaxLength(50)]
        public string? Status { get; set; }
    }
}