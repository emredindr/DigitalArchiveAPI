using DigitalArchive.Core.Dto.Response;
using DigitalArchive.Entities.ViewModels.CategoryVM;
namespace DigitalArchive.Business.Abstract
{
    public interface ICategoryAppService
    {
        Task<ListResult<GetAllCategoryInfo>> GetCategoryList(GetCategoryListInput input);
        Task<PagedResult<GetAllCategoryInfo>> GetAllCategoryByPage(GetAllCategoryInput input);
        Task<GetAllCategoryInfo> GetCategoryById(int categoryId);
        Task CreateCategory(CreateCategoryInput input);
        Task UpdateCategory(UpdateCategoryInput input);
        Task DeleteCategory(int categoryId);
    }
}
