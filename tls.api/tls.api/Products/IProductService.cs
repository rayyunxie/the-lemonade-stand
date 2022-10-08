namespace tls.api.Products
{
    public interface IProductService
    {
        Task<ProductDto> GetProduct(Guid id);
        Task<IEnumerable<ProductDto>> GetAllProducts();
    }
}