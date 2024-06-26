using api.src.Helpers;

namespace api.Helpers
{
    public class StudentQueryObject : BaseQueryObj
    {
        public string? Name { get; set; }
        public string? Status { get; set; }
    }
}