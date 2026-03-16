using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harfien.Application.DTO.Error;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Harfien.Application.Helpers
{
    public static class ErrorHelper
    {
        public static IActionResult HandleErrors(
            ControllerBase controller,
            IEnumerable<FieldErrorDto> serviceErrors = null,
            string message = "An error occurred",
            int statusCode = StatusCodes.Status400BadRequest)
        {
            var errorsList = new List<FieldErrorDto>();

       
            if (controller.ModelState != null && !controller.ModelState.IsValid)
            {
                foreach (var state in controller.ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        errorsList.Add(new FieldErrorDto
                        {
                            Field = state.Key,
                            Message = error.ErrorMessage
                        });
                    }
                }
            }
 
            if (serviceErrors != null)
                errorsList.AddRange(serviceErrors);

            var errorDto = new ErrorResponseDto
            {
                Message = message,
                ErrorsList = errorsList,
                Code = statusCode
            };

            return controller.StatusCode(statusCode, errorDto);
        }
    }
}
