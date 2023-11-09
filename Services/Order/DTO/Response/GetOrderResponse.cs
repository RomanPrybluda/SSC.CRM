namespace Services
{
    public class GetOrderResponse : CreateOrderRequest
    {
        public Guid OrderId { get; set; }
    }
}