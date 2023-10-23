using Bogus;
using DAL.DBContext;
using DAL.Entity;
using DAL.Enum;

namespace Domain.Seeds
{
    public class DocumentInitializer
    {
        private readonly AppDBContext _context;

        public DocumentInitializer(AppDBContext context)
        {
            _context = context;
        }

        public void InitializeDocuments()
        {
            var faker = new Faker();
            var existingDocumentCount = _context.Documents.Count();

            if (existingDocumentCount >= 500)
            {
                return;
            }

            var orders = _context.Orders.ToList();
            var ships = _context.Ships.ToList();

            var availabilityRequiredDocsValues = Enum.GetValues(typeof(AvailabilityRequiredDocs)).OfType<AvailabilityRequiredDocs>().ToArray();

            for (int i = 0; i < 500 - existingDocumentCount; i++)
            {
                var order = faker.PickRandom(orders);
                var ship = faker.PickRandom(ships);

                var document = new Document
                {
                    DocumenNumber = GenerateDocumentNumber(faker),
                    DocumenName = faker.Lorem.Word(),
                    Description = faker.Lorem.Sentence(),
                    ShipName = ship.ShipName,
                    AvailabilityRequiredDocs = faker.PickRandom(availabilityRequiredDocsValues),
                    Developer = faker.Company.CompanyName(),
                    OrderId = order.OrderId,
                    ShipId = ship.ShipId
                };

                _context.Documents.Add(document);
            }

            _context.SaveChanges();
        }

        private string GenerateDocumentNumber(Faker faker)
        {
            string number = faker.Random.Int(1, 9999).ToString("D4");
            string month = DateTime.Now.Month.ToString("D2");
            string year = DateTime.Now.Year.ToString();

            string documentNumber = $"SSC-{number}-{month}-{year}";

            return documentNumber;
        }
    }
}