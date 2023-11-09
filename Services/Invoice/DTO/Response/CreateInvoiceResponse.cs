namespace Services
{
    public class CreateInvoiceResponse : CreateInvoiceRequest
    {
        public Guid InvoiceId { get; set; }

        public DateTime OrderDate { get; set; }
    }
}