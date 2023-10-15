namespace Domain.Services.ContactPersonService.DTO
{
    public class CreateContactPersonResponse : CreateContactPersonRequest
    {
        public Guid ContactPersonId { get; set; }
    }
}