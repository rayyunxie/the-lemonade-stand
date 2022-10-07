using AutoMapper;
using tls.api.Errors;
using tls.api.Repositories;

namespace tls.api.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrderService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<OrderDto> CreateOrder(OrderForCreationDto orderForCreationDto)
        {
            var orderEntity = _mapper.Map<OrderEntity>(orderForCreationDto);

            _repositoryManager.Order.CreateOrder(orderEntity);
            await _repositoryManager.Save();

            return _mapper.Map<OrderDto>(orderEntity);
        }

        public async Task<OrderDto> GetOrder(Guid id)
        {
            var orderEntity = await GetOrderAndCheckIfItExists(id);
            return _mapper.Map<OrderDto>(orderEntity);
        }

        private async Task<OrderEntity> GetOrderAndCheckIfItExists(Guid id)
        {
            var orderEntity = await _repositoryManager.Order.GetOrder(id);
            if (orderEntity == null)
            {
                throw new OrderNotFoundException(id);
            }

            return orderEntity;
        }
    }
}