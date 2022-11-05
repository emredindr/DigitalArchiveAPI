using DigitalArchive.Core.Dto.Request;

namespace DigitalArchive.Entities.ViewModels.CategoryTypeVM
{
    public class GetAllCategoryTypeInput: PagedResultReguest
    {
        public string? SearchText { get; set; }

    }
}
