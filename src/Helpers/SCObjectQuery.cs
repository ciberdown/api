using api.src.Helpers;

namespace api.Helpers
{
    public class SCObjectQuery : BaseQueryObj
    {
        public int? StudentId { get; set; }

        public int? CourseId { get; set; }
        public int? Grade { get; set; }
    }
}