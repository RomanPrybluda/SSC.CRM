using DAL.Enum;

namespace DAL.Entity
{
    public class Ship : BaseEntity
    {
        public Guid ShipId { get; set; }

        public string? ImoNumber { get; set; }

        public string? ShipName { get; set; }

        public string? ShipPreviousName { get; set; }

        public string? ShipFirstName { get; set; }

        public ShipType ShipType { get; set; }

        public ClassSociety ClassSociety { get; set; }

        public double Dwt { get; set; }

        public double GrossTonnage { get; set; }

        public double NetTonnage { get; set; }

        public string? ShipOwner { get; set; }

        public string? ShipOperator { get; set; }

        public ICollection<Document> Documents { get; set; }

        //public Guid DocumentId { get; set; }

        //public Document Document { get; set; }

    }
}