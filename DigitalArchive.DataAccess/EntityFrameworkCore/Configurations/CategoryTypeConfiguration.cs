using DigitalArchive.Core.Constants;
using DigitalArchive.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalArchive.DataAccess.EntityFrameworkCore.Configurations
{
    public class CategoryTypeConfiguration : IEntityTypeConfiguration<CategoryType>
    {
        public void Configure(EntityTypeBuilder<CategoryType> builder)
        {
            builder.ToTable("CategoryType");
            builder.Property(c => c.Id).ValueGeneratedOnAdd(); 
            builder.Property(b => b.Name).HasMaxLength(CoreConsts.MaxLength50);
            builder.Property(b => b.Description).HasMaxLength(CoreConsts.MaxLength200);


        }
    }
}
