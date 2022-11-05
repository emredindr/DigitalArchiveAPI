using DigitalArchive.Core.Constants;
using DigitalArchive.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalArchive.DataAccess.EntityFrameworkCore.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.Property(c => c.Id);
            builder.Property(b => b.Name).HasMaxLength(CoreConsts.MaxLength50).IsRequired();
        }
    }
}
