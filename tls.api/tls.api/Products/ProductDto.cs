namespace tls.api.Products
{
    public record ProductDto
    {
        public Guid? Id { get; init; }
        public string? Name { get; init; }
        public string? Image { get; init; }
        public string? SizeName { get; init; }
        public int SizeValue { get; init; }
        public double Price { get; init; }
    }
}
