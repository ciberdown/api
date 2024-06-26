namespace api.Helpers
{
    public class StudentQueryObject
    {
        public string? Name { get; set; }
        public string? Status { get; set; }
        public int? SkipCount { get; set; }
        public int? MaxResultCount { get; set; }
    }
}