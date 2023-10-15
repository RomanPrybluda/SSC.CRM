using AutoMapper;
using DAL.Entity;
using Domain.Exceptions;
using Domain.Services.AppUserService.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services.AppUserService
{
    public class AppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AppUserService(UserManager<AppUser> repository, IMapper mapper)
        {
            _userManager = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAppUserResponse>> GetAllAppUsersAsync()
        {
            var appUsers = await _userManager.Users.ToListAsync();

            if (appUsers is null)
                throw new CustomException(CustomExceptionType.NotFound, "No app users found.");

            var appUserResponses = _mapper.Map<IEnumerable<GetAppUserResponse>>(appUsers);

            return appUserResponses;
        }

        public async Task<GetAppUserResponse> GetAppUserByIdAsync(Guid id)
        {
            var appUser = await _userManager.FindByIdAsync(id.ToString());

            if (appUser == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No app user with ID {id}.");

            var appUserResponse = _mapper.Map<GetAppUserResponse>(appUser);

            return appUserResponse;
        }

        public async Task<CreateAppUserResponse> CreateAppUserAsync(CreateAppUserRequest request)
        {
            var appUser = _mapper.Map<AppUser>(request);

            var result = await _userManager.CreateAsync(appUser);

            var appUserResponse = _mapper.Map<CreateAppUserResponse>(result);

            return appUserResponse;
        }

        public async Task<UpdateAppUserResponse> UpdateAppUserAsync(Guid id, UpdateAppUserRequest request)
        {
            var appUser = await _userManager.FindByIdAsync(id.ToString());

            if (appUser is null)
                throw new CustomException(CustomExceptionType.NotFound, $"No app user with ID {id}.");

            _mapper.Map(request, appUser);

            var result = await _userManager.UpdateAsync(appUser);

            var appUserResponse = _mapper.Map<UpdateAppUserResponse>(result);

            return appUserResponse;
        }

        public async Task DeleteAppUserAsync(Guid id)
        {
            var appUser = await _userManager.FindByIdAsync(id.ToString());

            if (appUser is null)
                throw new CustomException(CustomExceptionType.NotFound, $"No app user with ID {id}.");

            await _userManager.DeleteAsync(appUser);
        }
    }
}