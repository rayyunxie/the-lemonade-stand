using tls.api.Orders;
using tls.api.Products;

namespace tls.api.Service
{
    public interface IServiceManager
    {
        IOrderService Order { get; }
        IProductService Product { get; }
    }
}
