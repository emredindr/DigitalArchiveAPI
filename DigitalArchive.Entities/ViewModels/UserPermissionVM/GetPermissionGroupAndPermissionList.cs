namespace DigitalArchive.Entities.ViewModels.UserPermissionVM
{
    public class GetPermissionGroupAndPermissionList
    {
        public int PermissionGroupId { get; set; }
        public string PermissionGroupName { get; set; }
        public List<PermissionAndUserInfo> PermissionList { get; set; }
    }
}
