using DigitalArchive.Core.Entities.Audit;

namespace DigitalArchive.Core.DbModels
{
    public class UserDocument : FullAudited<int>
    {
        public string DocumentTitle { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int DocumentId { get; set; }
    }
}