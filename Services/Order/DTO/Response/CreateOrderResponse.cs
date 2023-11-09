namespace Services
{
    public class CreateOrderResponse : CreateOrderRequest
    {
        public Guid OrderId { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
