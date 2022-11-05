using System.ComponentModel.DataAnnotations;

namespace DigitalArchive.Core.Dto.Request
{
    [Serializable]
    public class LimitedResultRequest : ILimitedResultRequest
    {
        [Range(1, int.MaxValue)]
        public int MaxResultCount { get; set; } = 10;
    }
}
