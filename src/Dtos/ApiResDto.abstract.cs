

namespace api.Dtos
{
    public abstract class AbstactApiResDto<I>
    where I : class
    {
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }
        public virtual I? Body { get; set; }

        protected Exception ThrowError(string message){
            return new Exception(message);
        }
        protected void AddError(string errorMessage){
            Error = errorMessage ?? "Empty error message";
            IsSuccess = false;
            Body = null;
        }
        protected void CleanError(){
            Error = null;
            IsSuccess = true;
        }
    }
}