using AutoMapper;
using Microsoft.Extensions.Options;
using tls.api.Orders;
using tls.api.Repositories;

namespace tls.api.Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IOrderService> _orderService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, IOptions<AppOptions> appOptions)
        {
            _orderService = new Lazy<IOrderService>(() =>
                new OrderService(repositoryManager, mapper));
        }

        public IOrderService Order => _orderService.Value;
    }
}
