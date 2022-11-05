using DigitalArchive.Core.Constants;
using DigitalArchive.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalArchive.DataAccess.EntityFrameworkCore.Configurations
{
    public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            builder.ToTable("AuditLog");
            builder.Property(b => b.MethodName).HasMaxLength(CoreConsts.MaxLength50).IsRequired();
            builder.Property(b => b.ServiceName).HasMaxLength(CoreConsts.MaxLength50).IsRequired();
            builder.Property(b => b.Exception).HasMaxLength(CoreConsts.MaxLength100);


        }
    }
}
