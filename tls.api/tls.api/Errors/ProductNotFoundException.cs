namespace tls.api.Errors
{
    public sealed class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(Guid productId) :
            base("Product.Id", $"The product with id {productId} doesn't exist.")
        {
        }
    }
}
