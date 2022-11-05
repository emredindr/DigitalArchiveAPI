namespace DigitalArchive.Core.Dto.Request
{
    public interface IPagedResultReguest : ILimitedResultRequest
    {
        int SkipCount { get; set; }
    }
}
