using DigitalArchive.Business.Abstract;
using DigitalArchive.Core.DbModels;
using DigitalArchive.Core.Dto.Response;
using DigitalArchive.Core.Repositories;
using DigitalArchive.Entities.ViewModels.UserCategoryVM;
using Microsoft.EntityFrameworkCore;

namespace DigitalArchive.Business.Concreate;

public class UserCategoryAppService : BaseAppService, IUserCategoryAppService
{
    private readonly IRepository<User, int> _userRepository;
    private readonly IRepository<Category, int> _categoryRepository;
    private readonly IRepository<CategoryType, int> _categoryTypeRepository;
    private readonly IRepository<UserCategory, int> _userCategoryRepository;

    public UserCategoryAppService
        (
        IRepository<User, int> userRepository,
        IRepository<Category, int> categoryRepository,
        IRepository<CategoryType, int> categoryTypeRepository,
        IRepository<UserCategory, int> userCategoryRepository
        )
    {
        _userRepository = userRepository;
        _categoryRepository = categoryRepository;
        _categoryTypeRepository = categoryTypeRepository;
        _userCategoryRepository = userCategoryRepository;
    }

    public async Task CreateOrUpdateUserCategory(CreateOrUpdateUserCategoryInput input)
    {
        var checkUser = await _userRepository.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == input.UserId);
        if (checkUser == null)
        {
            throw new Exception("user bulunamadı ");
        }
        var userCategoryList = _userCategoryRepository.GetAllList(x => x.UserId == input.UserId);
        var userCategoryIdList = userCategoryList.Select(x => x.CategoryId).ToList();

        var selectedCategoryIdList = input.CategoryList.Select(x => x.CategoryId).ToList();

        //Silinecek Kayıtlar
        var differanceFromSelected = userCategoryIdList.Except(selectedCategoryIdList).ToList();

        //Eklenecek kayıtlar
        var differanceFromNotSelected = selectedCategoryIdList.Except(userCategoryIdList).ToList();

        foreach (var addItemId in differanceFromNotSelected)
        {
            await _userCategoryRepository.InsertAsync(new UserCategory
            {
                UserId = input.UserId,
                CategoryId = addItemId,
            });
        }
        foreach (var deleteItemId in differanceFromSelected)
        {

            var query = _userCategoryRepository.FirstOrDefault(x => x.CategoryId == deleteItemId && x.UserId == input.UserId);
            await _userCategoryRepository.RemoveAsync(query.Id);
        }

    }

    public async Task<ListResult<CategoryAndUserInfo>> GetCategoryAndUserList(int userId)
    {
        var checkUser = _userRepository.FirstOrDefault(x => !x.IsDeleted && x.Id == userId);
        if (checkUser == null)
        {
            throw new Exception("user bulunamadı");
        }

        List<CategoryAndUserInfo> result = new List<CategoryAndUserInfo>();

        var userCategoryList = await _userCategoryRepository.GetAll().Where(x => x.UserId == userId).ToListAsync();
        var allCategoryList = await _categoryRepository.GetAll().Where(x => !x.IsDeleted).ToListAsync();
        foreach (var item in allCategoryList)
        {
            var userCategoryCheck = userCategoryList.Any(x => x.CategoryId == item.Id);
            var resultItem = new CategoryAndUserInfo();
            resultItem.CategoryId = item.Id;
            resultItem.CategoryName = item.Name;
            resultItem.ParentCategoryId = item.ParentCategoryId;
            resultItem.IsChecked = userCategoryCheck;
            result.Add(resultItem);

        }
        return new ListResult<CategoryAndUserInfo>(result);
    }

    public async Task<List<Category>> GetUserCategories(int userId, int categoryId)
    {
        var result = from category in _categoryRepository.GetAll()
                     join userCategory in _userCategoryRepository.GetAll() on category.Id equals userCategory.CategoryId
                     where userCategory.UserId == userId && userCategory.CategoryId == categoryId
                     select category;
        return await result.ToListAsync();
    }
}
