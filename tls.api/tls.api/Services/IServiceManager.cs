using tls.api.Orders;

namespace tls.api.Service
{
    public interface IServiceManager
    {
        IOrderService Order { get; }
    }
}
