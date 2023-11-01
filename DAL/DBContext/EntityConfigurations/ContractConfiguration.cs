using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DBContext.EntityConfigurations
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("Contract");

            builder.HasKey(contract => contract.ContractId);

            builder.HasMany(contract => contract.Orders)
                    .WithOne(order => order.Contract)
                    .HasForeignKey(order => order.ContractId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(contract => contract.Invoices)
                    .WithOne(invoice => invoice.Contract)
                    .HasForeignKey(invoice => invoice.ContractId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.Property(contract => contract.ContractId)
                    .HasDefaultValueSql("NEWID()");

            builder.Property(contract => contract.ContractNumber)
                    .IsRequired();

            builder.Property(contract => contract.Title)
                    .IsRequired();

            builder.Property(contract => contract.Description)
                    .IsRequired();
        }
    }
}
