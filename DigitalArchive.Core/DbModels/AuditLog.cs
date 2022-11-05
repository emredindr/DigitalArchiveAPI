using DigitalArchive.Core.Entities;

namespace DigitalArchive.Core.DbModels
{
    public  class AuditLog :Entity<int>
    {
        public int UserId { get; set; }
        public string ServiceName { get; set; }
        public string MethodName { get; set; }
        public string Exception { get; set; }
        public DateTime TimeDuration { get; set; }

    }
}