using System.ComponentModel.DataAnnotations;

namespace Services
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