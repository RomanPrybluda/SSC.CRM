using DAL.Enum;

namespace Domain.Services.AppUserService.DTO
{
    public class GetAppUserResponse
    {
        public Guid AppUserId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public Position Position { get; set; }
    }
}
