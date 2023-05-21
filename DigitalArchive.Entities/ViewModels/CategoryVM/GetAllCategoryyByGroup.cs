namespace DigitalArchive.Entities.ViewModels.CategoryVM
{
    public class GetAllCategoryByGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentCategoryId { get; set; }
        public int CategoryTypeId { get; set; }
        public string CategoryTypeName { get; set; }
        public List<GetAllCategoryByGroup> Items { get; set; }
    }
}
