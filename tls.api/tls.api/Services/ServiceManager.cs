using AutoMapper;
using tls.api.Orders;
using tls.api.Products;
using tls.api.Repositories;

namespace tls.api.Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IOrderService> _orderService;
        private readonly Lazy<IProductService> _productService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _orderService = new Lazy<IOrderService>(() =>
                new OrderService(repositoryManager, mapper));

            _productService = new Lazy<IProductService>(() =>
                new ProductService(repositoryManager, mapper));
        }

        public IOrderService Order => _orderService.Value;
        public IProductService Product => _productService.Value;
    }
}
