using DigitalArchive.Core.Dto.Request;
using DigitalArchive.Entities.Enums;

namespace DigitalArchive.Entities.ViewModels.UserVM
{
    public class GetAllUserInput : ListResultReguest
    {
        public string? SearchText { get; set; }
        public UserStatusEnum IsActive { get; set; }
    }
}
