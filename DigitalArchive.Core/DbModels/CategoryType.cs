using DigitalArchive.Core.Entities;
using DigitalArchive.Core.Entities.Audit;

namespace DigitalArchive.Core.DbModels
{
    public class CategoryType:Entity<int>, ISoftDelete
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsDeleted { get; set; }
    }
}
