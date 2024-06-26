namespace api.Dtos
{
    public class CountedResDto<T>
    {
        public int TotalCount { get; set; }
        public List<T> Items { get; set; } = new List<T>();

        public CountedResDto(List<T>? list, int? SkipCount = null, int? MaxResultCount = null)
        {
            if (list != null){
                TotalCount = list.Count;
                Items = Pagination(list, SkipCount, MaxResultCount);
     
            }
        }
        protected List<T> Pagination(List<T> list, int? SkipCount, int? MaxResultCount)
        {

            SkipCount ??= 0;
            MaxResultCount ??= int.MaxValue;
            return list
                .Skip((int)SkipCount)
                .Take((int)MaxResultCount).ToList();
        }
    }

    public static class StaticCountedResDto
    {
        public static CountedResDto<T> ToCountedResDto<T>(this List<T> list, int? SkipCount = null, int? MaxResultCount = null){

            return new CountedResDto<T>(list, SkipCount, MaxResultCount);
        }
    }
    
}