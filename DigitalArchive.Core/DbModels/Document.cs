using DigitalArchive.Core.Entities.Audit;

namespace DigitalArchive.Core.DbModels
{
    public class Document:FullAudited<int>
    {
        public string Name { get; set; }
        public string ContentType { get; set; }
        public string DownloadUrl { get; set; }
    }
}
