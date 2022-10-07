using tls.api.Orders;

namespace tls.api.Repositories
{
    public enum RepositoryError
    {
        ConstraintViolation
    };

    public interface IRepositoryManager
    {
        IOrderRepository Order { get; }

        Task Save();
        Task SaveAndCheckError(RepositoryError repositoryError);
    }
}
