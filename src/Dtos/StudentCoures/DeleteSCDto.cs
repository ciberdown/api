using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.src.Dtos.StudentCoures
{
    public class DeleteSCDto
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int CourseId { get; set; }
    }
}