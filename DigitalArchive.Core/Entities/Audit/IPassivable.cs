namespace DigitalArchive.Core.Entities.Audit
{
    public interface IPassivable
    {
        bool IsActive { get; set; }
    }
}
