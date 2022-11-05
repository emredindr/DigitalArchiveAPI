namespace DigitalArchive.Core.Dto.Response
{
    public interface IPagedResult<T> : IListResult<T> where T : class
    {
        int TotalCount { get; set; }
    }
}
