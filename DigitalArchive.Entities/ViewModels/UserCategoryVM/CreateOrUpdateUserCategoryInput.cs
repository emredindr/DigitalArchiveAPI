namespace DigitalArchive.Entities.ViewModels.UserCategoryVM;

public class CreateOrUpdateUserCategoryInput
{
    public int UserId { get; set; }
    public List<CreateUserCategoryInput> CategoryList { get; set; }
}