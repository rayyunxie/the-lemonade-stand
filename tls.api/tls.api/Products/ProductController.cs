using Microsoft.AspNetCore.Mvc;
using tls.api.Service;

namespace tls.api.Products
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private const string GetProductRouteName = "ProductById";

        private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("{id:guid}", Name = GetProductRouteName)]
        [HttpHead("{id:guid}")]
        public async Task<ActionResult<ProductDto>> GetProduct(Guid id)
        {
            var productDto = await _serviceManager.Product.GetProduct(id);
            return Ok(productDto);
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDto>))]
        public async Task<IActionResult> GetAllProducts()
        {
            var productDtos = await _serviceManager.Product.GetAllProducts();
            return Ok(productDtos);
        }

        [HttpOptions]
        public IActionResult GetProductsOptions()
        {
            Response.Headers.Add("Allow", "GET, HEAD, OPTIONS");
            return Ok();
        }
    }
}