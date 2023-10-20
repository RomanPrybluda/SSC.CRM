using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DBContext.EntityConfigurations
{
    public class ShipConfiguration : IEntityTypeConfiguration<Ship>
    {
        public void Configure(EntityTypeBuilder<Ship> builder)
        {
            builder.HasKey(ship => ship.ShipId);

            builder.HasMany(ship => ship.Documents)
                    .WithOne(doc => doc.Ship)
                    .HasForeignKey(doc => doc.ShipId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.Property(ship => ship.ShipId)
                    .HasDefaultValueSql("NEWID()");

            builder.Property(ship => ship.ShipName)
                    .IsRequired()
                    .HasMaxLength(30);

            builder.Property(ship => ship.ImoNumber)
                    .IsRequired()
                    .HasPrecision(7);

            builder.Property(ship => ship.ShipType)
                    .IsRequired();

        }
    }
}