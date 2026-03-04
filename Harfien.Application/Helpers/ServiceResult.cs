using Harfien.Application.DTO.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Application.Helpers
{
    public  class ServiceResult <T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public List<FieldErrorDto> Errors { get; set; } = new();

        public static ServiceResult<T> Success(T data, string message = null)
            => new() { IsSuccess = true, Data = data, Message = message };

        public static ServiceResult<T> Failure(string message, List<FieldErrorDto> errors = null)
            => new() { IsSuccess = false, Message = message, Errors = errors ?? new() };
    
}
}
