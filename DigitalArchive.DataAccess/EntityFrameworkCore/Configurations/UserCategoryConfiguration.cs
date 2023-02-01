using DigitalArchive.Core.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DigitalArchive.DataAccess.EntityFrameworkCore.Configurations;

public class UserCategoryConfiguration : IEntityTypeConfiguration<UserCategory>
{
    public void Configure(EntityTypeBuilder<UserCategory> builder)
    {
        builder.ToTable("UserCategory");
    }
}
