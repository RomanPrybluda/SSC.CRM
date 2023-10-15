namespace Domain.Services.ServicesOrder.DTO
{
    public class GetOrderResponse : CreateOrderRequest
    {
        public Guid OrderId { get; set; }
    }
}