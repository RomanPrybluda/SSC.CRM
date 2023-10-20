namespace Domain.Services.AppUserService.DTO
{
    public class GetAppUserResponse : CreateAppUserResponse
    {
        public Guid AppUserId { get; set; }
    }
}
