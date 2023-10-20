using DAL.DBContext.EntityConfigurations;
using DAL.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.DBContext
{
    public class AppDBContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ContactPerson> ContactPersons { get; set; }

        public DbSet<Contract> Contracts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<Ship> Ships { get; set; }

        public DbSet<Invoice> Invoices { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ClientConfiguration().Configure(modelBuilder.Entity<Client>());

            new ContactPersonConfiguration().Configure(modelBuilder.Entity<ContactPerson>());

            new ContractConfiguration().Configure(modelBuilder.Entity<Contract>());

            new OrderConfiguration().Configure(modelBuilder.Entity<Order>());

            new DocumentConfiguration().Configure(modelBuilder.Entity<Document>());

            new ShipConfiguration().Configure(modelBuilder.Entity<Ship>());

            new InvoiceConfiguration().Configure(modelBuilder.Entity<Invoice>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
