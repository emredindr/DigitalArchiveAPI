using DigitalArchive.Core.Dto.Request;

namespace DigitalArchive.Entities.ViewModels.PermissionVM
{
    public class GetAllPermissionInput: PagedResultReguest
    {
        public string? SearchText { get; set; }
    }
}
