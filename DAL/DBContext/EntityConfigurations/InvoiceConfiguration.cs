using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DBContext.EntityConfigurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");

            builder.HasKey(invoice => invoice.InvoiceId);

            builder.Property(invoice => invoice.InvoiceId)
                    .HasDefaultValueSql("NEWID()");

            builder.Property(invoice => invoice.InvoiceNumber)
                    .IsRequired();

            builder.Property(invoice => invoice.Amount)
                    .HasColumnType("decimal(18, 2)")
                    .IsRequired();
        }
    }
}
