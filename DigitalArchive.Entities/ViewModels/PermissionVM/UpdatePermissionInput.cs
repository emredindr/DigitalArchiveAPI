namespace DigitalArchive.Entities.ViewModels.PermissionVM
{
    public class UpdatePermissionInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PermissionGroupId { get; set; }

    }
}
