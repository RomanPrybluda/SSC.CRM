namespace Domain.Services.ShipService.DTO
{
    public class CreateShipResponse : CreateShipRequest
    {
        public Guid ShipId { get; set; }
    }
}