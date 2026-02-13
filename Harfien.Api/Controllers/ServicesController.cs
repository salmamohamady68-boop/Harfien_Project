using Harfien.Application.DTO;
using Harfien.Application.Interfaces;
using Harfien.Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Harfien.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Carftsman")]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ServiceCreateDto serviceCreateDto)
        {
            if (serviceCreateDto is not null)
            {
              var service=  await _serviceService.CreateServiceAsync(serviceCreateDto);
                return Ok(service);
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ServiceUpdateDto dto)
        {
            var result = await _serviceService.UpdateServiceAsync(id, dto);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
            try
            {
                var deleted = await _serviceService.DeleteServiceAsync(id);
                if (!deleted)
                    return NotFound(new { message = $"Service with ID {id} not found." });

                return NoContent();
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { message = "An error occurred while deleting the service.", details = ex.Message });
            }
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
            if (service == null) return NotFound();
            return Ok(service);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var services = await _serviceService.GetServicesByCategoryAsync(categoryId);
            return Ok(services);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetFiltered([FromQuery] ServiceQueryDto query)
        {
            var result = await _serviceService.GetFilteredAsync(query);
            return Ok(result);
        }
    }
}
