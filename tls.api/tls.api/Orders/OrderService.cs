using AutoMapper;
using tls.api.Errors;
using tls.api.OrderProducts;
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
            await CheckProductValid(orderForCreationDto.Products!);

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

        private async Task CheckProductValid(IEnumerable<OrderProductDto> orderProductDtos)
        {
            var productIds = orderProductDtos.Select(i => i.ProductId ?? Guid.Empty);
            var productEntities = await _repositoryManager.Product.GeProductCollection(productIds);
            var missingProductIds = productIds.Except(productEntities.Select(i => i.Id));
            var missingCount = missingProductIds.Count();
            if (missingCount > 0)
            {
                throw missingCount > 1 ?
                    new ProductsNotFoundException(missingProductIds) :
                    new ProductNotFoundException(missingProductIds.First());
            }

            var productEntityMap = productEntities.ToDictionary(x => x.Id, x => x);
            var productsWithMismatchPrice = orderProductDtos.Where(
                i => Math.Abs(i.UnitPrice - productEntityMap[i.ProductId ?? Guid.Empty].Price) >= 0.01);
            var mistmatchCount = productsWithMismatchPrice.Count();
            if (mistmatchCount > 0)
            {
                throw mistmatchCount > 1 ?
                    new ProductsPriceMismatchException(productsWithMismatchPrice.Select(i => i.ProductId ?? Guid.Empty)) :
                    new ProductPriceMismatchException(productsWithMismatchPrice.First().ProductId ?? Guid.Empty);
            }
        }
    }
}