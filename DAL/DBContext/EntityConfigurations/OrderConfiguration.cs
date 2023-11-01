using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DBContext.EntityConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.OrderId);

            builder.HasMany(order => order.Documents)
                    .WithOne(doc => doc.Order)
                    .HasForeignKey(doc => doc.OrderId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.Property(order => order.OrderId)
                    .HasDefaultValueSql("NEWID()");

            builder.Property(order => order.OrderNumber)
                    .IsRequired();

            builder.Property(order => order.WorkOrderDescription)
                    .IsRequired();
        }
    }
}
