using api.Dtos;

namespace api.src.Dtos
{
    public class ApiListResDto<T> : AbstactApiResDto<CountedResDto<T>>
    {
        public CountedResDto<T>? Body { get; set; }

        public ApiListResDto(List<T> list, int? SkipCount = null, int? MaxResultCount = null)
        {   
            if(list != null)
            {
                Body = list.ToCountedResDto(SkipCount,MaxResultCount);
                CleanError();
            }
            else
                AddError("body is null");
        }
        public ApiListResDto(string errorMessage)
        {
            AddError(errorMessage);
        }
    }
}