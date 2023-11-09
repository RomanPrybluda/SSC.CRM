using AutoMapper;
using DAL.Entity;
using Services;

namespace WebAPI
{
    public class AppUserMappingProfile : Profile
    {
        public AppUserMappingProfile()
        {
            CreateMap<AppUser, GetAppUserResponse>();

            CreateMap<CreateAppUserRequest, AppUser>();
            CreateMap<AppUser, CreateAppUserResponse>();

            CreateMap<UpdateAppUserRequest, AppUser>();
            CreateMap<AppUser, UpdateAppUserResponse>();
        }
    }
}