using Bogus;
using DAL.DBContext;
using DAL.Entity;
using DAL.Enum;

namespace Domain.Seeds
{
    public class InvoiceInitializer
    {
        private readonly AppDBContext _context;

        public InvoiceInitializer(AppDBContext context)
        {
            _context = context;
        }

        public void InitializeInvoices()
        {
            var faker = new Faker();
            var existingInvoicesCount = _context.Invoices.Count();

            if (existingInvoicesCount < 200)
            {
                var contracts = _context.Contracts.ToList();
                var invoiceStatusValues = Enum.GetValues(typeof(InvoiceStatus)).OfType<InvoiceStatus>().ToArray();


                for (int i = 0; i < 200 - existingInvoicesCount; i++)
                {
                    if (contracts.Any())
                    {
                        var contract = faker.PickRandom(contracts);
                        var randomStatus = faker.PickRandom(invoiceStatusValues);

                        var invoice = new Invoice
                        {
                            InvoiceNumber = GenerateInvoiceNumber(faker),
                            Amount = faker.Finance.Amount(50, 10000, 2),
                            InvoiceStatus = randomStatus,
                            ContractId = contract.ContractId
                        };

                        _context.Invoices.Add(invoice);
                    }
                }

                _context.SaveChanges();
            }
        }


        private string GenerateInvoiceNumber(Faker faker)
        {
            string number = faker.Random.Int(1, 999).ToString("D3");
            string month = faker.Random.Int(1, 12).ToString("D2");
            string year = faker.Random.Int(2000, 2023).ToString();

            string invoiceNumber = $"{number}-{month}-{year}";

            return invoiceNumber;
        }

    }
}