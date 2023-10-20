using DAL.Enum;

namespace Domain.Services.AppUserService.DTO
{
    public class CreateAppUserRequest
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public Position Position { get; set; }
    }
}