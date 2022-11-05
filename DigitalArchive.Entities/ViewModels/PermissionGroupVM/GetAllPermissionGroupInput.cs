using DigitalArchive.Core.Dto.Request;

namespace DigitalArchive.Entities.ViewModels.PermissionGroupVM
{
    public class GetAllPermissionGroupInput: PagedResultReguest
    {
        public string? SearchText { get; set; }
    }
}
