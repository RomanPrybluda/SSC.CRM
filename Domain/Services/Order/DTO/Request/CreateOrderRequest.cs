using DAL.Enum;

namespace Domain.Services.ServicesOrder.DTO
{
    public class CreateOrderRequest
    {

        public string? OrderNumber { get; set; }

        public Guid ClientId { get; set; }

        public string? WorkOrderDescription { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }
}