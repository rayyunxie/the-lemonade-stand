namespace tls.api.Errors
{
    public sealed class ProductsNotFoundException : NotFoundException
    {
        public ProductsNotFoundException(IEnumerable<Guid> productIds) :
            base("Product.Id", $"Products with ids {String.Join(",", productIds)} don't exist.")
        {
        }
    }
}
