using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DBContext.EntityConfigurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(invoice => invoice.InvoiceId);

            builder.HasOne(invoice => invoice.Client)
                .WithMany(client => client.Invoices)
                .HasForeignKey(invoice => invoice.ClientId);

            builder.Property(invoice => invoice.InvoiceId)
                    .HasDefaultValueSql("NEWID()");

            builder.Property(invoice => invoice.InvoiceNumber)
                    .IsRequired();

            builder.Property(invoice => invoice.TotalAmount)
                    .IsRequired();

            builder.Property(invoice => invoice.TotalAmount)
                    .IsRequired()
                    .HasColumnType("decimal(18, 2)");
        }
    }
}
