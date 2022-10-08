using AutoMapper;
using tls.api.OrderProducts;
using tls.api.Orders;
using tls.api.Products;

namespace tls.api.DataTransfer
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<OrderEntity, OrderDto>();

            CreateMap<OrderForCreationDto, OrderEntity>()
                .ForMember(dto => dto.OrderProducts,
                    opt => opt.MapFrom(entity => entity.Products));
            CreateMap<OrderProductDto, OrderProductEntity>().ReverseMap();

            CreateMap<ProductEntity, ProductDto>()
                .ForMember(dto => dto.ImageUrl,
                    opt => opt.MapFrom(entity => entity.GetImageUrl()))
                .ForMember(dto => dto.Name,
                    opt => opt.MapFrom(entity => entity.ProductReference != null ? entity.ProductReference.Name : null));
        }
    }
}
