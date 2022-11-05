using DigitalArchive.Core.Dto.Request;
namespace DigitalArchive.Entities.ViewModels.CategoryVM
{
    public class GetAllCategoryInput: PagedResultReguest
    {

        public string? SearchText { get; set; }
    }
}
