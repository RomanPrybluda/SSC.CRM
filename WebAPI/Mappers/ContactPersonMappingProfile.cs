using AutoMapper;
using DAL.Entity;
using Services;

namespace WebAPI
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