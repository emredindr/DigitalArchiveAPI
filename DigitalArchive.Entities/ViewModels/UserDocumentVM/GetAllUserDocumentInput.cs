using DigitalArchive.Core.Dto.Request;

namespace DigitalArchive.Entities.ViewModels.UserDocumentVM
{
    public class GetAllUserDocumentInput: PagedResultReguest
    {
        public string SearchText { get; set; }
        public int? CategoryId { get; set; }
        public int? UserId { get; set; }

    }
}
