using api.Dtos;

namespace api.src.Dtos
{
    public class ApiResDto<T> : AbstactApiResDto<T> 
    where T : class
    {
        public T? Body { get; set; }

        public ApiResDto(T body)
        {
            if(body != null)
            {
                Body = body;
                CleanError();
            }
            else
                AddError("body is null");
        }

        public ApiResDto(string errorMessage)
        {
            AddError(errorMessage);
        }
    }
}