namespace DigitalArchive.Entities.ViewModels.CategoryVM
{
    public class UpdateCategoryInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryTypeId { get; set; }
        public int ParentCategoryId { get; set; }
    }
}
