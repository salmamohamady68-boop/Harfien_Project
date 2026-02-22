using Harfien.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Harfien.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CraftsmenController : ControllerBase
    {
        private readonly ICraftsmanService _service;

        public CraftsmenController(ICraftsmanService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
    }



}
