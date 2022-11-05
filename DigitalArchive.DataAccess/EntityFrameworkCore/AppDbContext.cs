using DigitalArchive.Core.DbModels;
using DigitalArchive.DataAccess.EntityFrameworkCore.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DigitalArchive.DataAccess.EntityFrameworkCore
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryType> CategoryTypes { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserDocument> UserDocuments { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<PermissionGroup> PermissionGroups { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AuditLogConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new UserDocumentConfiguration());
            modelBuilder.ApplyConfiguration(new UserPermissionConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionGroupConfiguration());

        }
    }
}
