using tls.api.Orders;
using tls.api.Products;

namespace tls.api.Repositories
{
    public enum RepositoryError
    {
        ConstraintViolation
    };

    public interface IRepositoryManager
    {
        IOrderRepository Order { get; }
        IProductRepository Product { get; }

        Task Save();
        Task SaveAndCheckError(RepositoryError repositoryError);
    }
}
