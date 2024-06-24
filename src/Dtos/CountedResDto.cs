namespace api.Dtos
{
    public class CountedResDto<T>
    {
        public int TotalCount { get; set; }
        public List<T> Items { get; set; } = new List<T>();
    }
}