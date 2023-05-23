using DigitalArchive.Core.Dto.Request;

namespace DigitalArchive.Entities.ViewModels.PermissionGroupVM
{
    public class GetAllPermissionGroupInput: ListResultReguest
    {
        public string? SearchText { get; set; }
    }
}
