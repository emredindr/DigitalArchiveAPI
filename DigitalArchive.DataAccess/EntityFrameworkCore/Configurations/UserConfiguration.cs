using DigitalArchive.Core.Constants;
using DigitalArchive.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalArchive.DataAccess.EntityFrameworkCore.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.Property(b => b.Id);
            builder.Property(b => b.Name).HasMaxLength(CoreConsts.MaxLength50).IsRequired();
            builder.Property(b => b.Surname).HasMaxLength(CoreConsts.MaxLength50);
            builder.Property(b => b.UserName).HasMaxLength(CoreConsts.MaxLength50);
            builder.Property(b => b.Email).HasMaxLength(CoreConsts.MaxLength50);

        }
    }
}