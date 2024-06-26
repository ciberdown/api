using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class CourseQueryObject
    {
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public int? SkipCount { get; set; }
        public int? MaxResultCount { get; set; }
    }
}