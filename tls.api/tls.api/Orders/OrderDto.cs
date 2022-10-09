using tls.api.OrderProducts;

namespace tls.api.Orders
{
    public record OrderDto
    {
        public Guid? Id { get; init; }
        public string? Name { get; init; }
        public string? Contact { get; init; }
        public IEnumerable<OrderProductDto>? OrderProducts { get; init; }
    }
}
