using Bogus;
using DAL.DBContext;
using DAL.Entity;
using DAL.Enum;

namespace Domain.Seeds
{
    public class ShipInitializer
    {
        private readonly AppDBContext _context;

        public ShipInitializer(AppDBContext context)
        {
            _context = context;
        }

        public void InitializeShips()
        {
            var faker = new Faker();
            var existingShipCount = _context.Ships.Count();

            if (existingShipCount >= 2500)
            {
                return;
            }

            var shipTypeValues = Enum.GetValues(typeof(ShipType)).OfType<ShipType>().ToArray();

            for (int i = 0; i < 2500 - existingShipCount; i++)
            {
                var ship = new Ship
                {
                    ImoNumber = GenerateImoNumber(faker),
                    ShipName = faker.Lorem.Word(),
                    ShipType = faker.PickRandom(shipTypeValues),
                    Dwt = faker.Random.Double(500, 200000),
                    ClassSociety = (ClassSociety)faker.Random.Int(0, 3),
                };

                _context.Ships.Add(ship);
            }

            _context.SaveChanges();
        }

        private string GenerateImoNumber(Faker faker)
        {
            return faker.Random.Number(1000000, 9999999).ToString();
        }
    }
}
