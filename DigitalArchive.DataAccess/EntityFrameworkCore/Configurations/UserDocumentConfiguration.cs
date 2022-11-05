using DigitalArchive.Core.Constants;
using DigitalArchive.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalArchive.DataAccess.EntityFrameworkCore.Configurations
{
    public class UserDocumentConfiguration : IEntityTypeConfiguration<UserDocument>
    {
        public void Configure(EntityTypeBuilder<UserDocument> builder)
        {
            builder.ToTable("UserDocument");
            builder.Property(b => b.DocumentTitle).HasMaxLength(CoreConsts.MaxLength100).IsRequired();
        }
    }
}
