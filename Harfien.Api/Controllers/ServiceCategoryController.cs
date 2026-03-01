using Harfien.Application.DTO.Error;
using Harfien.Application.DTO.ServiceCategory;
using Harfien.Application.Helpers;
using Harfien.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Harfien.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCategoryController : ControllerBase
    {
        private readonly IServiceCategoryService _service;

        public ServiceCategoryController(IServiceCategoryService service)
        {
            _service = service;
        }

        // ======== Get All ========
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _service.GetAllAsync();
            return Ok(categories);
        }

        // ======== Get By Id ========
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var serviceErrors = new List<FieldErrorDto>();
            var category = await _service.GetByIdAsync(id, serviceErrors);

            if (category == null)
                return ErrorHelper.HandleErrors(this, serviceErrors, "Service category not found", StatusCodes.Status404NotFound);

            return Ok(category);
        }

        // ======== Add ========
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add([FromBody] AddServiceCategoryDto dto)
        {
            if (!ModelState.IsValid)
                return ErrorHelper.HandleErrors(this, null, "Validation Error");

            var result = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // ======== Update ========
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] ServiceCategoryDto dto)
        {
            if (id != dto.Id)
                return ErrorHelper.HandleErrors(this,
                    serviceErrors: new List<FieldErrorDto> { new FieldErrorDto { Field = "Id", Message = "Id mismatch" } },
                    message: "Validation Error",
                    statusCode: StatusCodes.Status400BadRequest
                );

            if (!ModelState.IsValid)
                return ErrorHelper.HandleErrors(this, null, "Validation Error");

            var serviceErrors = new List<FieldErrorDto>();
            var updatedCategory = await _service.UpdateAsync(dto, serviceErrors);

            if (updatedCategory == null)
                return ErrorHelper.HandleErrors(this, serviceErrors, "Update failed", StatusCodes.Status404NotFound);

            return Ok(updatedCategory);
        }

        // ======== Delete ========
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var serviceErrors = new List<FieldErrorDto>();
            var deletedCategory = await _service.DeleteAsync(id, serviceErrors);

            if (deletedCategory == null)
                return ErrorHelper.HandleErrors(this, serviceErrors, "Delete failed", StatusCodes.Status404NotFound);

            return Ok(deletedCategory);
        }
    }
}