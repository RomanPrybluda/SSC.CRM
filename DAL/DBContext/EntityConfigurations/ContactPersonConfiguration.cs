using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DBContext.EntityConfigurations
{
    public class ContactPersonConfiguration : IEntityTypeConfiguration<ContactPerson>
    {
        public void Configure(EntityTypeBuilder<ContactPerson> builder)
        {
            builder.HasKey(contactPerson => contactPerson.ContactPersonId);

            builder.Property(contactPerson => contactPerson.ContactPersonId)
                    .HasDefaultValueSql("NEWID()");

            builder.Property(contactPerson => contactPerson.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

            builder.Property(contactPerson => contactPerson.LastName)
                    .IsRequired()
                    .HasMaxLength(30);

            builder.Property(contactPerson => contactPerson.Email)
                    .IsRequired();

            builder.Property(contactPerson => contactPerson.Phone)
                    .IsRequired();

            builder.Property(contactPerson => contactPerson.Position)
                    .IsRequired();
        }
    }
}