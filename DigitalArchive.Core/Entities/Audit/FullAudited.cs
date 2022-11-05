namespace DigitalArchive.Core.Entities.Audit
{
    public abstract class FullAudited<TPrimeryKey> : Entity<TPrimeryKey>, IFullAudited, ISoftDelete
    {
        public int? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public int? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public int? DeletorUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
