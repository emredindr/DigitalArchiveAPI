namespace DigitalArchive.Business.Abstract
{
    public interface IDocumentAppService
    {
        Task<int> CreateAndGetDocumentId(string fileName,string contentType);
    }
}
