namespace DigitalArchive.Core.Dto.Response
{
    [Serializable]
    public class ListResult<T> : IListResult<T> where T : class
    {
        private IReadOnlyList<T> _items;
        public ListResult()
        {

        }
        public ListResult(IReadOnlyList<T> items)
        {
            Items = items;
        }
        public IReadOnlyList<T> Items
        {
            get
            {
                return _items ?? (_items = new List<T>());
            }
            set
            {
                _items = value;
            }
        }
    }
}
