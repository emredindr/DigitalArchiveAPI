namespace DigitalArchive.Entities.ViewModels.UserDocumentVM
{
    public class GetAllUserDocumentInfo
    {
        public DocumentUserInfo DocumentUser { get; set; }
        public DocumentCategoryInfo DocumentCategory { get; set; }
        public DocumentCategoryTypeInfo DocumentCategoryType { get; set; }

        public DocumentInfo DocumentInfo { get; set; }
        public int UserDocumentId { get; set; }
        public string DocumentTitle { get; set; }
        public DateTime CreationTime { get; set; }
    }
    public class DocumentUserInfo
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName => Name + " " + Surname;
    }
    public class DocumentCategoryInfo
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }



    }
    public class DocumentInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public string DownloadUrl { get; set; }

    }
    public class DocumentCategoryTypeInfo
    {
        public int CategoryTpyeId { get; set; }
        public string Name { get; set; }


    }

}
