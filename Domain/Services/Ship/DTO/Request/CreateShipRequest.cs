using DAL.Enum;
using System.ComponentModel.DataAnnotations;

namespace Domain.Services.ShipService.DTO
{
    public class CreateShipRequest
    {
        [Required]
        [StringLength(7)]
        [RegularExpression("^[0-9]*$")]
        public string? ImoNumber { get; set; }

        [Required]
        [MaxLength(30)]
        public string? ShipName { get; set; }

        [Required]
        public ShipType ShipType { get; set; }

        [Required]
        [RegularExpression(@"^\d+(\.\d+)?$")]
        public double Dwt { get; set; }

        [Required]
        public ClassSociety ClassSociety { get; set; }

    }
}