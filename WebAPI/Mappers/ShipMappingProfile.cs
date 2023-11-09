using AutoMapper;
using DAL.Entity;
using Services;

namespace WebAPI
{
    public class ShipMappingProfile : Profile
    {
        public ShipMappingProfile()
        {
            CreateMap<Ship, GetShipResponse>();

            CreateMap<CreateShipRequest, Ship>();
            CreateMap<Ship, CreateShipResponse>();

            CreateMap<UpdateShipRequest, Ship>();
            CreateMap<Ship, UpdateShipResponse>();
        }
    }
}