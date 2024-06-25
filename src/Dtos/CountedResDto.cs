namespace api.Dtos
{
    public class CountedResDto<T>
    {
        public int TotalCount { get; set; }
        public List<T> Items { get; set; } = new List<T>();

        public CountedResDto(List<T>? list)
        {
            TotalCount = list.Count;
            Items = list;
        }
    }

    public static class StaticCountedResDto
    {
        public static CountedResDto<T> ToCountedResDto<T>(this List<T> list){
            return new CountedResDto<T>(list);
        }
    }
}