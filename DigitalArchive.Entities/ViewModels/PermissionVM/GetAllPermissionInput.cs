using DigitalArchive.Core.Dto.Request;

namespace DigitalArchive.Entities.ViewModels.PermissionVM
{
    public class GetAllPermissionInput: ListResultReguest
    {
        public string? SearchText { get; set; }
    }
}
