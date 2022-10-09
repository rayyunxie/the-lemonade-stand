namespace tls.api.Errors
{
    public sealed class ProductsPriceMismatchException : BadRequestException
    {
        public ProductsPriceMismatchException(IEnumerable<Guid> productIds) :
            base("Product.Price", $"Products with ids {String.Join(",", productIds)} have mismatched price.")
        {
        }
    }
}
