using DigitalArchive.Core.Constants;
using DigitalArchive.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalArchive.DataAccess.EntityFrameworkCore.Configurations
{
    public class PermissionGroupConfiguration : IEntityTypeConfiguration<PermissionGroup>
    {
        public void Configure(EntityTypeBuilder<PermissionGroup> builder)
        {
            builder.ToTable("PermissionGroup");
            builder.Property(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(CoreConsts.MaxLength50).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(CoreConsts.MaxLength200);

        }
    }
}
