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

            builder.Property(order => order.OrderId)
                    .HasDefaultValueSql("NEWID()");

            builder.Property(order => order.OrderNumber)
                    .IsRequired();

            builder.Property(order => order.WorkOrderDescription)
                    .IsRequired();

            builder.Property(order => order.ClientId)
                    .IsRequired();
        }
    }
}
