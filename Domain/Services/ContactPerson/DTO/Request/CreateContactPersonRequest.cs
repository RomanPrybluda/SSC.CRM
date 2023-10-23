using System.ComponentModel.DataAnnotations;

namespace Domain.Services.ContactPersonService.DTO
{
    public class CreateContactPersonRequest
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Phone { get; set; }

        [Required]
        public string? Position { get; set; }

        public string? Notes { get; set; }

        [Required]
        public Guid ClientId { get; set; }
    }
}