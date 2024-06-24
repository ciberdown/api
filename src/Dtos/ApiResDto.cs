using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Dtos
{
    public class ApiResDto<T>
    where T : class
    {
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }
        public T? Body { get; set; }

        public ApiResDto(T? body)
        {
            IsSuccess = body != null;
            Error = body == null ? "data empty error" : null;
            Body = body;
        }

        public ApiResDto(string errorText)
        {
            IsSuccess = false;
            Error = errorText;
            Body = null;
        }

        private Exception ThrowError(string message){
            return new Exception(message);
        }
    }
}