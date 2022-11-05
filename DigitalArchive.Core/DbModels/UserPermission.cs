using DigitalArchive.Core.Entities;

namespace DigitalArchive.Core.DbModels
{
    public class UserPermission : Entity<int>
    {
        public int PermissionId { get; set; }
        public int UserId { get; set; }
    }
}
