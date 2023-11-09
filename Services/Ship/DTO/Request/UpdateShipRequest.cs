namespace Services
{
    public class UpdateShipRequest : CreateShipRequest
    {
        public string ShipPreviousName { get; set; } = string.Empty;

        public string ShipFirstName { get; set; } = string.Empty;

        public double GrossTonnage { get; set; }

        public double NetTonnage { get; set; }

        public string ShipOwner { get; set; } = string.Empty;

        public string ShipOperator { get; set; } = string.Empty;
    }
}
