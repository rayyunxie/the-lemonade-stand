using tls.api.Products;

namespace tls.api.Orders
{
    public record OrderDto
    {
        public Guid? Id { get; init; }
        public string? Name { get; init; }
        public string? Contact { get; init; }
        public IEnumerable<ProductDto>? Products { get; init; }
    }
}
