using AutoMapper;
using DAL.Entity;
using Services;

namespace WebAPI
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, GetOrderResponse>();

            CreateMap<CreateOrderRequest, Order>();
            CreateMap<Order, CreateOrderResponse>();

            CreateMap<UpdateOrderRequest, Order>();
            CreateMap<Order, UpdateOrderResponse>();
        }
    }
}