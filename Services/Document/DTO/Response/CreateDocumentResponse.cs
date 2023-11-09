namespace Services
{
    public class CreateDocumentResponse
    {
        public Guid DocumentId { get; set; }

        public string? DocumenNumber { get; set; }

        public string? DocumenName { get; set; }

        public string? Description { get; set; }
    }
}
