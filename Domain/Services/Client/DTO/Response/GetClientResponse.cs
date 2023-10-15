namespace Domain.Services.ClientService.DTO
{
    public class GetClientResponse
    {
        public Guid ClientId { get; set; }

        public string? CompanyName { get; set; }

        public string? Address { get; set; }

        public string? ContactEmail { get; set; }

        public string? ContactPhone { get; set; }
    }
}