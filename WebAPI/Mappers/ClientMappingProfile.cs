using AutoMapper;
using DAL.Entity;
using Services;

namespace WebAPI
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<Client, GetClientResponse>();

            CreateMap<CreateClientRequest, Client>();
            CreateMap<Client, CreateClientResponse>();

            CreateMap<UpdateClientRequest, Client>();
            CreateMap<Client, UpdateClientResponse>();
        }
    }
}