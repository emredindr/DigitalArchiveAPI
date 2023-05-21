using DigitalArchive.Business.Abstract;
using DigitalArchive.Core.DbModels;
using DigitalArchive.Core.Repositories;

namespace DigitalArchive.Business.Concreate
{
    public class DocumentAppService : BaseAppService, IDocumentAppService
    {
        private readonly IRepository<Document, int> _documentrepository;
        public DocumentAppService(IRepository<Document, int> documentrepository)
        {
            _documentrepository = documentrepository;
        }

        public async Task<int> CreateAndGetDocumentId(string fileName, string contentType)
        {
            return await _documentrepository.InsertAndGetIdAsync(new Document() { Name = fileName, ContentType = contentType, CreationTime = DateTime.UtcNow });
        }
        public async Task<int> CreateAndGetDocumentId(string fileName, string contentType, string downloadUrl)
        {
            var asd = await _documentrepository.InsertAndGetIdAsync(new Document() { Name = fileName, ContentType = contentType, DownloadUrl = downloadUrl, CreationTime = DateTime.UtcNow });
            return asd;
        }
    }
}
