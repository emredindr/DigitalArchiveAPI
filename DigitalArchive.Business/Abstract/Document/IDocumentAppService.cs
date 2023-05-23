namespace DigitalArchive.Business.Abstract
{
    public interface IDocumentAppService
    {
        Task<int> CreateAndGetDocumentId(string fileName, string contentType);
        Task<int> CreateAndGetDocumentIdFirebase(string fileName, string contentType, string downloadUrl);

    }
}
