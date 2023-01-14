using DigitalArchive.Core.Constants;
using DigitalArchive.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalArchive.DataAccess.EntityFrameworkCore.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission");
            builder.Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(c => c.PermissionGroupId);
            builder.Property(c => c.Code).HasMaxLength(CoreConsts.MaxLength50).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(CoreConsts.MaxLength50).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(CoreConsts.MaxLength200);


        }
    }
}
