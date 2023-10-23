using Bogus;
using DAL.DBContext;
using DAL.Entity;

namespace Domain.Seeds
{
    public class ContactPersonInitializer
    {
        private readonly AppDBContext _context;

        public ContactPersonInitializer(AppDBContext context)
        {
            _context = context;
        }

        public void InitializeContactPersons()
        {
            var faker = new Faker();

            var existingContactPersonsCount = _context.ContactPersons.Count();

            if (existingContactPersonsCount < 60)
            {
                var clients = _context.Clients.ToList();

                for (int i = 0; i < 60 - existingContactPersonsCount; i++)
                {
                    var client = faker.PickRandom(clients);
                    var contactPerson = new ContactPerson
                    {
                        FirstName = faker.Name.FirstName(),
                        LastName = faker.Name.LastName(),
                        Email = faker.Internet.Email(),
                        Phone = faker.Phone.PhoneNumber(),
                        Position = faker.Name.JobTitle(),
                        Notes = faker.Lorem.Sentence(),
                        ClientId = client.ClientId
                    };

                    _context.ContactPersons.Add(contactPerson);
                }

                _context.SaveChanges();
            }
        }
    }
}
