using AutoMapper;
using DAL.Entity;
using Domain.Services.ContactPersonService.DTO;

namespace Domain.Mappers
{
    public class ContactPersonMappingProfile : Profile
    {
        public ContactPersonMappingProfile()
        {
            CreateMap<ContactPerson, GetContactPersonResponse>();

            CreateMap<CreateContactPersonRequest, ContactPerson>();
            CreateMap<ContactPerson, CreateContactPersonResponse>();

            CreateMap<UpdateContactPersonRequest, ContactPerson>();
            CreateMap<ContactPerson, UpdateContactPersonResponse>();
        }
    }
}