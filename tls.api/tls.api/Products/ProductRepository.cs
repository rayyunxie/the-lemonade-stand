using tls.api.Repositories;

namespace tls.api.Products
{
    using Microsoft.EntityFrameworkCore;
    using Entity = ProductEntity;

    public class ProductRepository : RepositoryBase<Entity>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public Task<Entity?> GetProduct(Guid id) =>
            GetAll().Include(entity => entity.ProductReference).FirstOrDefaultAsync(entity => entity.Id == id);

        public Task<List<Entity>> GetAllProducts() =>
            GetAll().Include(entity => entity.ProductReference).ToListAsync();

        public Task<List<Entity>> GeProductCollection(IEnumerable<Guid> ids) =>
            FindByCondition(entity => ids.Contains(entity.Id)).ToListAsync();

        public Task<Entity?> TrackProduct(Guid id) =>
            GetAllAsTracking().FirstOrDefaultAsync(entity => entity.Id == id);

        public Task<bool> HasProduct(Guid id) =>
            GetAll().AnyAsync(entity => entity.Id == id);

        public void CreateProduct(Entity Product) =>
            Create(Product);
    }
}