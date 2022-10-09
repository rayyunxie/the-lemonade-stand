namespace tls.api.Errors
{
    public sealed class ProductPriceMismatchException : BadRequestException
    {
        public ProductPriceMismatchException(Guid productId) :
            base("Product.Price", $"The product with id {productId} has mismatched price.")
        {
        }
    }
}
