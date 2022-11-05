namespace DigitalArchive.Core.Dto.Response
{
    public interface IListResult<T> where T : class
    {
        IReadOnlyList<T> Items { get; set; }

    }
}
