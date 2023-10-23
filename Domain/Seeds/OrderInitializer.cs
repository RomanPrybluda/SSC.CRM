using Bogus;
using DAL.DBContext;
using DAL.Entity;

namespace Domain.Seeds
{
    public class OrderInitializer
    {
        private readonly AppDBContext _context;

        public OrderInitializer(AppDBContext context)
        {
            _context = context;
        }

        public void InitializeOrders()
        {
            var faker = new Faker();
            var existingOrderCount = _context.Orders.Count();

            if (existingOrderCount >= 700)
            {
                return;
            }

            var contracts = _context.Contracts.ToList();

            for (int i = 0; i < 700 - existingOrderCount; i++)
            {
                var contract = faker.PickRandom(contracts);

                var order = new Order
                {
                    OrderNumber = GenerateOrderNumber(faker),
                    ContractId = contract.ContractId,
                    WorkOrderDescription = faker.Lorem.Sentence(),
                };

                _context.Orders.Add(order);
            }

            _context.SaveChanges();
        }

        private string GenerateOrderNumber(Faker faker)
        {
            string number = faker.Random.Int(1, 999).ToString("D3");
            string month = faker.Random.Int(1, 12).ToString("D2");
            string year = faker.Random.Int(2000, 2023).ToString();

            string orderNumber = $"{number}-{month}-{year}";

            return orderNumber;
        }
    }
}
