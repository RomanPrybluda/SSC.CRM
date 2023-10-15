namespace Domain.Services.ServicesOrder.DTO
{
    public class GetAllOrderResponse : CreateOrderRequest
    {
        public Guid OrderId { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
