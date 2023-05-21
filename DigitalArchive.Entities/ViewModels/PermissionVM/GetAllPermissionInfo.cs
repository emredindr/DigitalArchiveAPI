namespace DigitalArchive.Entities.ViewModels.PermissionVM
{
    public class GetAllPermissionInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PermissionGroupId { get; set; }
        public string PermissionGroupName { get; set; }
        public string PermissionGroupDescription { get; set; }

    }
}
