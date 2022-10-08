using Microsoft.AspNetCore.Mvc;
using tls.api.Service;

namespace tls.api.Orders
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private const string GetOrderRouteName = "OrderById";

        private readonly IServiceManager _serviceManager;

        public OrderController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("{id:guid}", Name = GetOrderRouteName)]
        [HttpHead("{id:guid}")]
        public async Task<ActionResult<OrderDto>> GetOrder(Guid id)
        {
            var orderDto = await _serviceManager.Order.GetOrder(id);
            return Ok(orderDto);
        }

        [HttpPost(Name = "CreateOrder")]
        public async Task<CreatedAtRouteResult> PostOrder([FromBody] OrderForCreationDto orderForCreationDto)
        {
            var orderDto = await _serviceManager.Order.CreateOrder(orderForCreationDto);
            return CreatedAtRoute(GetOrderRouteName, new { id = orderDto.Id }, orderDto);
        }

        [HttpOptions]
        public IActionResult GetOrdersOptions()
        {
            Response.Headers.Add("Allow", "GET, HEAD, POST, OPTIONS");
            return Ok();
        }
    }
}