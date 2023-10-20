using System.ComponentModel.DataAnnotations;

namespace Domain.Services.ClientService.DTO
{
    public class CreateClientRequest
    {
        [Required]
        public string? CompanyName { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        [EmailAddress]
        public string? ContactEmail { get; set; }

        [Required]
        public string? ContactPhone { get; set; }
    }
}