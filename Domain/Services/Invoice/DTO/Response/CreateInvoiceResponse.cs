namespace Domain.Services.InvoiceServices.DTO
{
    public class CreateInvoiceResponse : CreateInvoiceRequest
    {
        public Guid InvoiceId { get; set; }

        public DateTime OrderDate { get; set; }
    }
}