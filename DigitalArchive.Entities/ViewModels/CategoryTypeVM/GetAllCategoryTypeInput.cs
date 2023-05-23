using DigitalArchive.Core.Dto.Request;

namespace DigitalArchive.Entities.ViewModels.CategoryTypeVM
{
    public class GetAllCategoryTypeInput: ListResultReguest
    {
        public string? SearchText { get; set; }

    }
}
