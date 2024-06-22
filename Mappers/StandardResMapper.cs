using api.Dtos;

namespace api.Mappers
{
    public static class StandardResMapper
    {
        public static StandardResDto<T> ToStandardRes<T>(this List<T> list){
            return new StandardResDto<T>
            {
                TotalCount = list.Count,
                Items = list
            };
        }
    }
}