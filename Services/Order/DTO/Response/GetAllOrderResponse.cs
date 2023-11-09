namespace Services
{
    public class GetAllOrderResponse : CreateOrderRequest
    {
        public Guid OrderId { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
