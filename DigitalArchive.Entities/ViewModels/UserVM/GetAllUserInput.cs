using DigitalArchive.Core.Dto.Request;
using DigitalArchive.Entities.Enums;

namespace DigitalArchive.Entities.ViewModels.UserVM
{
    public class GetAllUserInput : PagedResultReguest
    {
        public string? SearchText { get; set; }
        public UserStatusEnum IsActive { get; set; }
    }
}
