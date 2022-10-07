namespace tls.api.Orders
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrder(OrderForCreationDto OrderForCreationDto);
        Task<OrderDto> GetOrder(Guid id);
    }
}