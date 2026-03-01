using System;
using Harfien.Application.DTO.Error;
using Harfien.Application.DTO.Service;
using Harfien.Application.Helpers;
using Harfien.Application.Interfaces;
using Harfien.Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Harfien.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        [Authorize(Roles = "Craftsman")]
        [HttpPost]
      
        public async Task<IActionResult> Create([FromBody] ServiceCreateDto dto)
        {
            var serviceErrors = new List<FieldErrorDto>();


            var result = await _serviceService.CreateServiceAsync(dto, serviceErrors);

            if (!ModelState.IsValid || serviceErrors.Any())
                return ErrorHelper.HandleErrors(this, serviceErrors, "Service creation failed");

            return Ok(result);
        }
        [Authorize(Roles = "Craftsman")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ServiceUpdateDto dto)
        {
            var serviceErrors = new List<FieldErrorDto>();
            var result = await _serviceService.UpdateServiceAsync(id, dto,serviceErrors);
            if (!ModelState.IsValid || serviceErrors.Any())
                return ErrorHelper.HandleErrors(this, serviceErrors, "Service update failed");
            return Ok(result);
        }
        [Authorize(Roles = "Craftsman")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             
                var deleted = await _serviceService.DeleteServiceAsync(id);
                if (!deleted)
                {
                    var errors = new List<FieldErrorDto>
                    {
                        new FieldErrorDto
                        {
                            Field = "id",
                            Message = $"Service with ID {id} not found."
                        }
                    };
                    return ErrorHelper.HandleErrors(  this, serviceErrors: errors,   message: "Delete operation failed", 
                        statusCode: StatusCodes.Status404NotFound);
                }

                    return NoContent();
       
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var services = await _serviceService.GetAllServicesAsync();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var service = await _serviceService.GetServiceByIdAsync(id);
            if (service == null)
                
                {
                    var errors = new List<FieldErrorDto>
                    {
                        new FieldErrorDto
                        {
                            Field = "id",
                            Message = $"Service with ID {id} not found."
                        }
                    };
                    return ErrorHelper.HandleErrors(this, serviceErrors: errors, message: "GetById operation failed",
                        statusCode: StatusCodes.Status404NotFound);
                }
            return Ok(service);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId, int pageNumber, int pageSize)
        {
            var serviceErrors = new List<FieldErrorDto>();
            var services = await _serviceService.GetServicesByCategoryAsync(categoryId,pageNumber,pageSize,serviceErrors);
            if (!ModelState.IsValid || serviceErrors.Any())
                return ErrorHelper.HandleErrors(this, serviceErrors, "Service get by category failed",404);
            return Ok(services);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetFiltered([FromQuery] ServiceQueryDto query)
        {
            var result = await _serviceService.GetFilteredAsync(query);
            return Ok(result);
        }
        [HttpGet("craftsman/{craftsmanId}")]
        public async Task<IActionResult> GetByCraftsmanId(  int craftsmanId,  [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
        {
            var serviceErrors = new List<FieldErrorDto>();
            var result = await _serviceService
                .GetServicesByCraftsmanIdAsync(craftsmanId, pageNumber, pageSize, serviceErrors);
            
            if (!ModelState.IsValid || serviceErrors.Any())
                return ErrorHelper.HandleErrors(this, serviceErrors, "Service get by craftmanid failed", 404);
            return Ok(result);
        }
    }
}
