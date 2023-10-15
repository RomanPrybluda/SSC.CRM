using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DBContext.EntityConfigurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(u => u.RefreshToken)
                    .HasMaxLength(256);

            builder.Property(u => u.RefreshTokenExpiryTime)
                    .HasColumnType("datetime");
        }
    }
}