using DigitalArchive.Core.DbModels;
using DigitalArchive.Core.Dto.Response;
using DigitalArchive.Entities.ViewModels.UserCategoryVM;

namespace DigitalArchive.Business.Abstract;

public interface IUserCategoryAppService
{
    Task<List<Category>> GetUserCategories(int userId, int categoryId);
    Task<ListResult<CategoryAndUserInfo>> GetCategoryAndUserList(int userId);

    Task CreateOrUpdateUserCategory(CreateOrUpdateUserCategoryInput input);
}