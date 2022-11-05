namespace DigitalArchive.Core.Entities.Audit
{
    public interface IDeletionAudited
    {
        int? DeletorUserId { get; set; }
        DateTime? DeletionTime { get; set; }

    }
}
