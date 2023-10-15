using AutoMapper;
using DAL.Entity;
using Domain.Services.ClientService.DTO;

namespace Domain.Mappers
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