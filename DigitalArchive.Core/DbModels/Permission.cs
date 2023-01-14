using DigitalArchive.Core.Entities.Audit;

namespace DigitalArchive.Core.DbModels
{
    public class Permission : FullAudited<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int PermissionGroupId { get; set; }

    }
}
