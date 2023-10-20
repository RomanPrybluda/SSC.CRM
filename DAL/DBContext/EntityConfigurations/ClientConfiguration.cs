using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DBContext.EntityConfigurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(client => client.ClientId);

            builder.HasMany(c => c.ContactPersons)
                    .WithOne(cp => cp.Client)
                    .HasForeignKey(cp => cp.ClientId);

            builder.HasMany(c => c.Contracts)
                    .WithOne(contract => contract.Client)
                    .HasForeignKey(cp => cp.ClientId);

            builder.Property(client => client.ClientId)
                    .HasDefaultValueSql("NEWID()");

            builder.Property(client => client.CompanyName)
                    .IsRequired()
                    .HasMaxLength(30);

            builder.Property(client => client.ContactEmail)
                    .IsRequired();

            builder.Property(client => client.ContactPhone)
                    .IsRequired();
        }
    }
}