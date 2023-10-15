namespace Domain.Services.ClientService.DTO
{
    public class CreateClientResponse : CreateClientRequest
    {
        public Guid ClientId { get; set; }
    }
}