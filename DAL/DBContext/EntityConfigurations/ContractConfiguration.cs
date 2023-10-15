using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DBContext.EntityConfigurations
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasKey(contract => contract.ContractId);

            builder.Property(contract => contract.ContractId)
                    .HasDefaultValueSql("NEWID()");

            builder.Property(contract => contract.ContractNumber)
                    .IsRequired();

            builder.Property(contract => contract.Title)
                    .IsRequired();

            builder.Property(contract => contract.Description)
                    .IsRequired();

            builder.Property(contract => contract.TotalAmount)
                    .IsRequired()
                    .HasColumnType("decimal(18, 2)");
        }
    }
}
