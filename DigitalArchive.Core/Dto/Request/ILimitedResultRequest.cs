namespace DigitalArchive.Core.Dto.Request
{
    public interface ILimitedResultRequest
    {
        int MaxResultCount { get; set; }
    }
}
