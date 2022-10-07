using tls.api.Repositories;

namespace tls.api.Orders
{
    using Microsoft.EntityFrameworkCore;
    using Entity = OrderEntity;

    public class OrderRepository : RepositoryBase<Entity>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public Task<Entity?> GetOrder(Guid id) =>
            GetAll().FirstOrDefaultAsync(entity => entity.Id == id);

        public Task<Entity?> TrackOrder(Guid id) =>
            GetAllAsTracking().FirstOrDefaultAsync(entity => entity.Id == id);

        public Task<bool> HasOrder(Guid id) =>
            GetAll().AnyAsync(entity => entity.Id == id);

        public void CreateOrder(Entity order) =>
            Create(order);
    }
}