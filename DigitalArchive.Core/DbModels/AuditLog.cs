using DigitalArchive.Core.Entities;
using System;

namespace DigitalArchive.Core.DbModels
{
    public  class AuditLog :Entity<int>
    {
        public int UserId { get; set; }
        public string ServiceName { get; set; }
        public string MethodName { get; set; }
        public string Exception { get; set; }
        public DateTimeOffset TimeDuration { get; set; }

    }
}