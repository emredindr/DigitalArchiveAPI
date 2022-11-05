namespace DigitalArchive.Entities.ViewModels.CategoryVM
{
    public class GetCategoryListInput
    {
        public string SearchText { get; set; }
        public int? CategoryTypeId { get; set; }
        public int? ParentCategoryId { get; set; }

    }
}
