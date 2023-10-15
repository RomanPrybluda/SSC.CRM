using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DBContext.EntityConfigurations
{
    internal class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasKey(document => document.DocumentId);

            builder.Property(document => document.DocumentId)
                    .HasDefaultValueSql("NEWID()");

            builder.Property(document => document.DocumenNumber)
                    .IsRequired();

            builder.Property(document => document.DocumenName)
                    .IsRequired();

            builder.Property(document => document.ShipName)
                    .IsRequired();

            builder.Property(document => document.ShipImoNumber)
                    .IsRequired();
        }
    }
}
