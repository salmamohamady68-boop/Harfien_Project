using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Harfien.Application.DTO.Error
{
    public class ErrorResponseDto
    {
        public string Message { get; set; }
        public List<FieldErrorDto> ErrorsList { get; set; } = new();
        public int? Code { get; set; }
    }
}
