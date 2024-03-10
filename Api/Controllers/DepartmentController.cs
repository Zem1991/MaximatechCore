using Domain.Dtos;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _service;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(ILogger<DepartmentController> logger
            , IDepartmentService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DepartmentDto>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetAllAsync()
        {
            IEnumerable<DepartmentDto> result = await _service.GetAllAsync();
            if (result != null) return Ok(result);
            string message = "Departments not found";
            _logger.LogInformation(message);
            return NotFound(message);
        }
    }
}
