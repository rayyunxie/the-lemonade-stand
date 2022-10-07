namespace tls.api.Orders
{
    using Entity = Orders.OrderEntity;
    public interface IOrderRepository
    {
        Task<Entity?> GetOrder(Guid id);
        Task<Entity?> TrackOrder(Guid id);
        Task<bool> HasOrder(Guid id);
        void CreateOrder(Entity order);
    }
}