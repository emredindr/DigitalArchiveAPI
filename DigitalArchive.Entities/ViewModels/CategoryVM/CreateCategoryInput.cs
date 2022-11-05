namespace DigitalArchive.Entities.ViewModels.CategoryVM
{
    public class CreateCategoryInput
    {
        public string Name { get; set; }
        public int CategoryTypeId { get; set; }
        public int ParentCategoryId { get; set; }
    }
}
