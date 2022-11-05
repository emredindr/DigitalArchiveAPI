using DigitalArchive.Core.Constants;
using DigitalArchive.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalArchive.DataAccess.EntityFrameworkCore.Configurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("Document");
            builder.Property(b => b.Name).HasMaxLength(CoreConsts.MaxLength100);
            builder.Property(b => b.ContentType).HasMaxLength(CoreConsts.MaxLength100);

        }
    }
}
