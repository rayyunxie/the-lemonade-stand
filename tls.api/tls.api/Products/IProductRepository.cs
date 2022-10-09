namespace tls.api.Products
{
    using Entity = ProductEntity;
    public interface IProductRepository
    {
        Task<Entity?> GetProduct(Guid id);
        Task<List<Entity>> GetAllProducts();
        Task<List<Entity>> GeProductCollection(IEnumerable<Guid> ids);
        Task<Entity?> TrackProduct(Guid id);
        Task<bool> HasProduct(Guid id);
        void CreateProduct(Entity Product);
    }
}