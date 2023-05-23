using DigitalArchive.Core.Dto.Request;
namespace DigitalArchive.Entities.ViewModels.CategoryVM
{
    public class GetAllCategoryInput: ListResultReguest
    {

        public string? SearchText { get; set; }
    }
}
