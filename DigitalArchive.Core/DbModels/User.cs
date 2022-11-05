using DigitalArchive.Core.Entities.Audit;

namespace DigitalArchive.Core.DbModels
{
    public class User : FullAudited<int>, IPassivable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }

    }
}
