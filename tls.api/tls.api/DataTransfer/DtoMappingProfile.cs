using AutoMapper;
using tls.api.Orders;

namespace tls.api.DataTransfer
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            // Order mapping
            CreateMap<OrderEntity, OrderDto>();
            CreateMap<OrderForCreationDto, OrderEntity>();
        }
    }
}
