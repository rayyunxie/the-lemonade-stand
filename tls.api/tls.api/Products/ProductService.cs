using AutoMapper;
using tls.api.Errors;
using tls.api.Repositories;

namespace tls.api.Products
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ProductDto> GetProduct(Guid id)
        {
            var productEntity = await GetProductAndCheckIfItExists(id);
            return _mapper.Map<ProductDto>(productEntity);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var productEntities = await _repositoryManager.Product.GetAllProducts();
            return _mapper.Map<IEnumerable<ProductDto>>(productEntities);
        }

        private async Task<ProductEntity> GetProductAndCheckIfItExists(Guid id)
        {
            var productEntity = await _repositoryManager.Product.GetProduct(id);
            if (productEntity == null)
            {
                throw new ProductNotFoundException(id);
            }

            return productEntity;
        }
    }
}