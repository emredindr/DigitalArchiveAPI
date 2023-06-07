using DigitalArchive.Core.DbModels;

namespace DigitalArchive.Entities.ViewModels.PermissionVM;

public class GetAllPermissionInfoByGroup
{
    public int PermissionGroupId { get; set; }
    public string PermissionName { get; set; }
    public string PermissionGroupDescription { get; set; }
    public List<PermissionDto> PermissionList { get; set; }
}
