using Domain.Dtos;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger
            , IProductService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllAsync()
        {
            IEnumerable<ProductDto> result = await _service.GetAllAsync();
            if (result != null) return Ok(result);
            string message = "Products not found";
            _logger.LogInformation(message);
            return NotFound(message);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ProductDto>> GetByIdAsync(int id)
        {
            ProductDto? result = await _service.GetByIdAsync(id);
            if (result != null) return Ok(result);
            string message = "Product not found";
            _logger.LogInformation(message);
            return NotFound(message);
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<bool>> CreateAsync([FromBody] ProductDto body)
        {
            bool result = await _service.CreateAsync(body);
            if (result) return Ok(result);
            string message = "Product creation was not possible.";
            _logger.LogInformation(message);
            return NotFound(message);
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<bool>> UpdateAsync([FromBody] ProductDto body)
        {
            bool result = await _service.UpdateAsync(body);
            if (result) return Ok(result);
            string message = "Product update was not possible.";
            _logger.LogInformation(message);
            return NotFound(message);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<bool>> DeleteAsync(int id)
        {
            bool result = await _service.DeleteAsync(id);
            if (result) return Ok(result);
            string message = "Product delete was not possible.";
            _logger.LogInformation(message);
            return NotFound(message);
        }
    }
}
