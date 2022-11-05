namespace DigitalArchive.Entities.ViewModels.UserDocumentVM
{
    public class CreateUserDocumentInput
    {
        public int DocumentId { get; set; }
        public string DocumentTitle { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
