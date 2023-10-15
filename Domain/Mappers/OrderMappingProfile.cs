using AutoMapper;
using DAL.Entity;
using Domain.Services.ServicesOrder.DTO;

namespace Domain.Mappers
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