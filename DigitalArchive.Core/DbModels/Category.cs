using DigitalArchive.Core.Entities.Audit;

namespace DigitalArchive.Core.DbModels
{
    public class Category : FullAudited<int>
    {
        public string Name { get; set; }
        public int CategoryTypeId  { get; set; }
        public int ParentCategoryId { get; set; }
    }
}
