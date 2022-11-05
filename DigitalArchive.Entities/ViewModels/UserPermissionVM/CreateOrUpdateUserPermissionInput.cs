namespace DigitalArchive.Entities.ViewModels.UserPermissionVM
{
    public class CreateOrUpdateUserPermissionInput
    {
        public int UserId { get; set; }
        public List<CreateUserPermissionInput> PermissionList { get; set; }
    }

    public class CreateUserPermissionInput
    {
        public int PermissionId { get; set; }
    }
}
