namespace DigitalArchive.Entities.ViewModels.UserCategoryVM;

public class CategoryAndUserInfo
{
    public int CategoryId { get; set; }
    public int ParentCategoryId { get; set; }
    public string CategoryName { get; set; }
    public bool IsChecked { get; set; }
}