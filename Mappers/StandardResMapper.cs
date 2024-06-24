using api.Dtos;

namespace api.Mappers
{
    public static class StandardResMapper
    {
        public static CountedResDto<T> ToCountedResDto<T>(this List<T> list){
            return new CountedResDto<T>
            {
                TotalCount = list.Count,
                Items = list
            };
        }
    }
}