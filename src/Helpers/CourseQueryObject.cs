using api.src.Helpers;

namespace api.Helpers
{
    public class CourseQueryObject : BaseQueryObj
    {
        public string? CourseName { get; set; }
        public string? Description { get; set; }
    }
}