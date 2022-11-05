namespace DigitalArchive.Entities.ViewModels.UserDocumentVM
{
    public class UpdateUserDocumentInput
    {
        public int UserDocumentId { get; set; }
        public int DocumentId { get; set; }
        public string DocumentTitle { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
