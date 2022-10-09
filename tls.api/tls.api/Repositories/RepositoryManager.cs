using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using tls.api.Errors;
using tls.api.Orders;
using tls.api.Products;

namespace tls.api.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IOrderRepository> _orderRepository;
        private readonly Lazy<IProductRepository> _productRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(repositoryContext));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(repositoryContext));
        }

        public IOrderRepository Order => _orderRepository.Value;
        public IProductRepository Product => _productRepository.Value;

        public Task Save()
        {
            var entries = _repositoryContext.ChangeTracker
                .Entries<OrderEntity>()
                .Where(entity => entity.State == EntityState.Added);

            foreach (var entityEntry in entries)
            {
                entityEntry.Entity.CreatedDate = DateTime.Now.ToUniversalTime();
            }

            return _repositoryContext.SaveChangesAsync();
        }

        public async Task SaveAndCheckError(RepositoryError repositoryError)
        {
            try
            {
                await _repositoryContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex) when (
                repositoryError == RepositoryError.ConstraintViolation &&
                ex.InnerException is SqlException sqlException &&
                sqlException.Number == 547)
            {
                throw new ConstraintViolationRepositoryException();
            }
        }
    }
}
